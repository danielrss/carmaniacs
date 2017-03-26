using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Stories;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.StoryService
{
    [TestFixture]
    public class Comment_Should
    {
        [Test]
        public void ThrowArgumentException_WhenStoryIdIsEmpty()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => storyService.Comment(Guid.Empty, "raandoomStriing1", "raandoomStriing2"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCommentIsNull()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => storyService.Comment(Guid.NewGuid(), "raandoomStriing1", null));
        }

        [Test]
        public void ThrowArgumentException_WhenUserIdIsEmpty()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => storyService.Comment(Guid.NewGuid(), "raandoomStriing1", string.Empty));
        }
    }
}
