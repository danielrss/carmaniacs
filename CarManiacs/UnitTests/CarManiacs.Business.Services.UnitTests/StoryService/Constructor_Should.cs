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

            //Act
            var storyService = new Services.StoryService(storiesRepoMock.Object);

            //Assert
            Assert.IsInstanceOf<IStoryService>(storyService);
        }

        [Test]
        public void ThrowArgumentNullException_WhenStoryRepositoryIsNull()
        {
            //Arrange && Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Services.StoryService(null));
        }
    }
}
