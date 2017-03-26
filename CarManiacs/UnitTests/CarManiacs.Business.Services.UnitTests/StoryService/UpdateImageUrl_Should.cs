using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Stories;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.StoryService
{
    [TestFixture]
    public class UpdateImageUrl_Should
    {
        [Test]
        public void CallStoryRepoUpdateOnce_WhenUserIsExistent()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object);
            var storyFromRepo = new Mock<Story>();
            var storyId = Guid.NewGuid();
            storiesRepoMock.Setup(m => m.GetById(storyId)).Returns(storyFromRepo.Object);

            //Act
            storyService.UpdateMainImageUrl(storyId, "tootaallyyRandomImageUrl");

            //Assert
            storiesRepoMock.Verify(m => m.Update(storyFromRepo.Object), Times.Once);
        }

        [Test]
        public void NotCallStoryRepoUpdate_WhenUserIsNonExistent()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyId = Guid.NewGuid();
            var storyService = new Services.StoryService(storiesRepoMock.Object);
            Story storyFromRepo = null;
            storiesRepoMock.Setup(m => m.GetById(storyId)).Returns(storyFromRepo);

            //Act
            storyService.UpdateMainImageUrl(storyId, "tootaallyyRandomImageUrl2");

            //Assert
            storiesRepoMock.Verify(m => m.Update(storyFromRepo), Times.Never);
        }

        [Test]
        public void ThrowArgumentException_WhenStoryIdIsEmpty()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => storyService.UpdateMainImageUrl(Guid.Empty, "raandoomStriing2"));
        }
    }
}
