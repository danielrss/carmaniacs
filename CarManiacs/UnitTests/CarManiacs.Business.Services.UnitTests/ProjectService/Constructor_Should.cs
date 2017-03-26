using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Projects;
using CarManiacs.Business.Services.Contracts;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.ProjectService
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateObjectOfTypeIProjectService_WhenParamsAreValid()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();

            //Act
            var projectService = new Services.ProjectService(projectsRepoMock.Object);

            //Assert
            Assert.IsInstanceOf<IProjectService>(projectService);
        }

        [Test]
        public void ThrowArgumentNullException_WhenProjectRepositoryIsNull()
        {
            //Arrange && Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Services.ProjectService(null));
        }
    }
}
