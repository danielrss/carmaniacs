using CarManiacs.Business.Models.Projects;
using CarManiacs.Business.Models.Users;
using CarManiacs.Business.Services.Contracts;
using CarManiacs.WebClient.Models;
using Moq;
using NUnit.Framework;
using System;
using TestStack.FluentMVCTesting;

namespace CarManiacs.WebClient.UnitTests.ProjectsController
{
    [TestFixture]
    public class Details_Should
    {
        [Test]
        public void ReturnHttpNotFound_WhenUserFromRepoIsNull()
        {
            // Arrange
            var regularUserServiceMock = new Mock<IRegularUserService>();
            var projectServiceMock = new Mock<IProjectService>();
            var projectsController = new WebClient.Controllers.ProjectsController(projectServiceMock.Object, regularUserServiceMock.Object);
            Project projectFromService = null;
            var projectId = Guid.NewGuid();
            projectServiceMock.Setup(m => m.GetById(projectId)).Returns(projectFromService);

            //Act & Assert
            projectsController
                .WithCallTo(c => c.Details(projectId))
                .ShouldGiveHttpStatus(404);
        }
    }
}
