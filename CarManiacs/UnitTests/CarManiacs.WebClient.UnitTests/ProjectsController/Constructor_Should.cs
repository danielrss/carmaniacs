using CarManiacs.Business.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.WebClient.UnitTests.ProjectsController
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateProjectsController_WhenParamsAreValid()
        {
            // Arrange
            var regularUserServiceMock = new Mock<IRegularUserService>();
            var projectServiceMock = new Mock<IProjectService>();
            var projectsController = new WebClient.Controllers.ProjectsController(projectServiceMock.Object, regularUserServiceMock.Object);

            //Act & Assert
            Assert.That(projectsController, Is.Not.Null.And.InstanceOf<WebClient.Controllers.ProjectsController>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenRegularUserServiceIsNull()
        {
            //Arrange
            var projectServiceMock = new Mock<IProjectService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new WebClient.Controllers.ProjectsController(projectServiceMock.Object, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenProjectServiceIsNull()
        {
            //Arrange
            var regularUserServiceMock = new Mock<IRegularUserService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new WebClient.Controllers.ProjectsController(null, regularUserServiceMock.Object));
        }
    }
}
