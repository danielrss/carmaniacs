using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Stories;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.StoryService
{
    [TestFixture]
    public class StarOrUnstar_Should
    {
        [Test]
        public void ThrowArgumentException_WhenStoryIdIsEmpty()
        {
            //Arrange
            var storysRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storysRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => storyService.StarOrUnstar(Guid.Empty, "raandoomStriing2"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            //Arrange
            var storysRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storysRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => storyService.StarOrUnstar(Guid.NewGuid(), null));
        }

        [Test]
        public void ThrowArgumentException_WhenUserIdIsEmpty()
        {
            //Arrange
            var storysRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storysRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => storyService.StarOrUnstar(Guid.NewGuid(), string.Empty));
        }
    }
}
