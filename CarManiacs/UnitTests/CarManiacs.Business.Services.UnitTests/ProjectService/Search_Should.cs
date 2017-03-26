using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Projects;

using Moq;
using NUnit.Framework;

namespace CarManiacs.Business.Services.UnitTests.ProjectService
{
    [TestFixture]
    public class Search_Should
    {
        [Test]
        public void CallProjectRepoAllOnce_WhenSearchParamIsValid()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act
            projectService.Search("someRandomSearchParam123");

            //Assert
            projectsRepoMock.Verify(m => m.All, Times.Once);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ReturnNull_WhenSearchParamIsNullOrEmpty(string searchParam)
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.IsNull(projectService.Search(searchParam));
        }
    }
}
