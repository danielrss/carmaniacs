using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Stories;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.StoryService
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void CallStoryRepoGetByIdOnce()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);
            var id = Guid.NewGuid();

            //Act
            storyService.GetById(id);

            //Assert
            storiesRepoMock.Verify(m => m.GetById(id), Times.Once);
        }
    }
}
