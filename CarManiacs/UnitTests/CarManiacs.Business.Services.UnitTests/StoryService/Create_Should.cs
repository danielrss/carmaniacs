using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Stories;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.StoryService
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void CallStoryRepoAddOnce_WhenIdIsValid()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object);
            var userId = Guid.NewGuid().ToString();
            var storyDto = new Mock<StoryDto>();

            //Act
            storyService.Create(storyDto.Object, userId);

            //Assert
            storiesRepoMock.Verify(m => m.Add(It.IsAny<Story>()), Times.Once);
        }

        [Test]
        public void ThrowArgumentNullException_WhenStoryDtoIsNull()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object);
            var userId = Guid.NewGuid().ToString();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => storyService.Create(null, userId));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object);
            var storyDto = new Mock<StoryDto>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => storyService.Create(storyDto.Object, null));
        }

        [Test]
        public void ThrowArgumentException_WhenUserIdIEmpty()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object);
            var storyDto = new Mock<StoryDto>();

            //Act && Assert
            Assert.Throws<ArgumentException>(() => storyService.Create(storyDto.Object, string.Empty));
        }
    }
}
