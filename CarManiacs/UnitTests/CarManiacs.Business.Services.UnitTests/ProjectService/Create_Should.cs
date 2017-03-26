using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Projects;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.ProjectService
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void CallProjectRepoAddOnce_WhenIdIsValid()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);
            var userId = Guid.NewGuid().ToString();
            var projectDto = new Mock<ProjectDto>();

            //Act
            projectService.Create(projectDto.Object, userId);

            //Assert
            projectsRepoMock.Verify(m => m.Add(It.IsAny<Project>()), Times.Once);
        }

        [Test]
        public void ThrowArgumentNullException_WhenProjectDtoIsNull()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);
            var userId = Guid.NewGuid().ToString();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => projectService.Create(null, userId));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);
            var projectDto = new Mock<ProjectDto>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => projectService.Create(projectDto.Object, null));
        }

        [Test]
        public void ThrowArgumentException_WhenUserIdIEmpty()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);
            var projectDto = new Mock<ProjectDto>();

            //Act && Assert
            Assert.Throws<ArgumentException>(() => projectService.Create(projectDto.Object, string.Empty));
        }
    }
}
