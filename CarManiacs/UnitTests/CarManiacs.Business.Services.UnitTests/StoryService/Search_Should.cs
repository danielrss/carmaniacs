using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Stories;

using Moq;
using NUnit.Framework;

namespace CarManiacs.Business.Services.UnitTests.StoryService
{
    [TestFixture]
    public class Search_Should
    {
        [Test]
        public void CallStoryRepoAllOnce_WhenSearchParamIsValid()
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);

            //Act
            storyService.Search("someRandomSearchParam123");

            //Assert
            storiesRepoMock.Verify(m => m.All, Times.Once);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ReturnNull_WhenSearchParamIsNullOrEmpty(string searchParam)
        {
            //Arrange
            var storiesRepoMock = new Mock<IEfRepository<Story>>();
            var storyStarsRepoMock = new Mock<IEfRepository<StoryStar>>();
            var storyService = new Services.StoryService(storiesRepoMock.Object, storyStarsRepoMock.Object);

            //Act && Assert
            Assert.IsNull(storyService.Search(searchParam));
        }
    }
}
