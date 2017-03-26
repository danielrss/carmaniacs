using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Stories;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.StoryService
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void CallStoryRepoUpdateOnce_WhenStoryIsExistent()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyDto = new StoryDto() { Id = Guid.NewGuid() };
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);
            var storyFromRepo = new Mock<Story>();
            storiesRepoMock.Setup(m => m.GetById(storyDto.Id)).Returns(storyFromRepo.Object);

            //Act
            storyService.Update(storyDto);

            //Assert
            storiesRepoMock.Verify(m => m.Update(storyFromRepo.Object), Times.Once);
        }

        [Test]
        public void NotCallStoryRepoUpdateOnce_WhenStoryIsExistent()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyDto = new StoryDto() { Id = Guid.NewGuid() };
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);
            Story storyFromRepo = null;
            storiesRepoMock.Setup(m => m.GetById(storyDto.Id)).Returns(storyFromRepo);

            //Act
            storyService.Update(storyDto);

            //Assert
            storiesRepoMock.Verify(m => m.Update(storyFromRepo), Times.Never);
        }

        [Test]
        public void ThrowArgumentNullException_WhenStoryDtoIsNull()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => storyService.Update(null));
        }
    }
}
