using CarManiacs.Business.Common;
using CarManiacs.Business.Models.Projects;
using CarManiacs.Business.Services.Contracts;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace CarManiacs.WebClient.UnitTests.ProjectsController
{
    [TestFixture]
    public class LoadPage_Should
    {
        public void ReturnJsonResult_WhenProjectsCollectionIsEmpty()
        {
            // Arrange
            var regularUserServiceMock = new Mock<IRegularUserService>();
            var projectServiceMock = new Mock<IProjectService>();
            var projectsController = new WebClient.Controllers.ProjectsController(projectServiceMock.Object, regularUserServiceMock.Object);
            var projectMock = new Mock<Project>();

            //Act & Assert
            projectsController
                .WithCallTo(c => c.LoadPage(3))
                .ShouldReturnJson();

            projectServiceMock.Verify(m => m.Get(3, Constants.InitialEntitiesPerPage), Times.Once);
        }
    }
}
