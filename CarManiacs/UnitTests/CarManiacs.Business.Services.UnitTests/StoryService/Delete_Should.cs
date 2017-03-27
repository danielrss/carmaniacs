using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Stories;
using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.StoryService
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void CallStoryRepoUpdateOnce_WhenStoryIsExistent()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);
            var storyFromRepo = new Mock<Story>();
            var storyId = Guid.NewGuid();
            storiesRepoMock.Setup(m => m.GetById(storyId)).Returns(storyFromRepo.Object);

            //Act
            storyService.Delete(storyId);

            //Assert
            storiesRepoMock.Verify(m => m.Update(storyFromRepo.Object), Times.Once);
        }

        [Test]
        public void NotCallStoryRepoUpdate_WhenStoryIsNonExistent()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyId = Guid.NewGuid();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);
            Story storyFromRepo = null;
            storiesRepoMock.Setup(m => m.GetById(storyId)).Returns(storyFromRepo);

            //Act
            storyService.Delete(storyId);

            //Assert
            storiesRepoMock.Verify(m => m.Update(storyFromRepo), Times.Never);
        }

        [Test]
        public void ThrowArgumentException_WhenStoryIdIsEmpty()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => storyService.Delete(Guid.Empty));
        }
    }
}
