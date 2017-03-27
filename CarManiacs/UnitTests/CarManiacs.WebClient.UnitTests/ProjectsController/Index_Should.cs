using CarManiacs.Business.Common;
using CarManiacs.Business.Services.Contracts;
using CarManiacs.WebClient.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;

namespace CarManiacs.WebClient.UnitTests.ProjectsController
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultViewAndCallProjectService()
        {
            // Arrange
            var regularUserServiceMock = new Mock<IRegularUserService>();
            var projectServiceMock = new Mock<IProjectService>();
            var projectsController = new WebClient.Controllers.ProjectsController(projectServiceMock.Object, regularUserServiceMock.Object);

            //Act & Assert
            projectsController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<ProjectShortViewModel>>();

            projectServiceMock.Verify(m => m.Get(0, Constants.EntitiesPerPage), Times.Once);
        }
    }
}
