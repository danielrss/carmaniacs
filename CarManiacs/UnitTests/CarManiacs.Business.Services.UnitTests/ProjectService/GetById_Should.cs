using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Projects;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.ProjectService
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void CallProjectRepoGetByIdOnce()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);
            var id = Guid.NewGuid();

            //Act
            projectService.GetById(id);

            //Assert
            projectsRepoMock.Verify(m => m.GetById(id), Times.Once);
        }
    }
}
