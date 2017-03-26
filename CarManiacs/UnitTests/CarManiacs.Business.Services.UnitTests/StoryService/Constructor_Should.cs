using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Stories;
using CarManiacs.Business.Services.Contracts;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.StoryService
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateObjectOfTypeIStoryService_WhenParamsAreValid()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();

            //Act
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);

            //Assert
            Assert.IsInstanceOf<IStoryService>(storyService);
        }

        [Test]
        public void ThrowArgumentNullException_WhenStoryRepositoryIsNull()
        {
            //Arrange
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Services.StoryService(null, storyStarsRepoMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenStoryStarRepositoryIsNull()
        {
            //Arrange
            var storyRepoMock = new Mock<IEfRepository<Story>>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Services.StoryService(storyRepoMock.Object, null));
        }
    }
}
