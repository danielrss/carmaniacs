using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Stories;
using Moq;
using NUnit.Framework;

namespace CarManiacs.Business.Services.UnitTests.StoryService
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void CallStoryRepoAllOnce()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);

            //Act
            storyService.GetAll();

            //Assert
            storiesRepoMock.Verify(m => m.All, Times.Once);
        }
    }
}
