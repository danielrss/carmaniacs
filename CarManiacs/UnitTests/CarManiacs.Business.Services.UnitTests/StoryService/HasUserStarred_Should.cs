using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Stories;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.StoryService
{
    [TestFixture]
    public class HasUserStarred_Should
    {
        [Test]
        public void ReturnFalse_WhenStoryIsNonExistent()
        {
            //Arrange
            var storysRepoMock = new Mock<IEfRepository<Story>>();
            var storyId = Guid.NewGuid();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storysRepoMock.Object, storyStarsRepoMock.Object);
            Story storyFromRepo = null;
            storysRepoMock.Setup(m => m.GetById(storyId)).Returns(storyFromRepo);

            //Act && Assert
            Assert.IsFalse(storyService.HasUserStarred(storyId, "tootaallyyRandomImageUrl2"));
        }

        [Test]
        public void ThrowArgumentException_WhenStoryIdIsEmpty()
        {
            //Arrange
            var storysRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storysRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => storyService.HasUserStarred(Guid.Empty, "raandoomStriing2"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            //Arrange
            var storysRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storysRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => storyService.HasUserStarred(Guid.NewGuid(), null));
        }

        [Test]
        public void ThrowArgumentException_WhenUserIdIsEmpty()
        {
            //Arrange
            var storysRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storysRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => storyService.HasUserStarred(Guid.NewGuid(), string.Empty));
        }
    }
}
