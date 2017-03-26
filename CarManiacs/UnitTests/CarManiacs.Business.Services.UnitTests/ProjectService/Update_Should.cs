using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Projects;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.ProjectService
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void CallProjectRepoUpdateOnce_WhenProjectIsExistent()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectDto = new ProjectDto() { Id = Guid.NewGuid() };
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);
            var projectFromRepo = new Mock<Project>();
            projectsRepoMock.Setup(m => m.GetById(projectDto.Id)).Returns(projectFromRepo.Object);

            //Act
            projectService.Update(projectDto);

            //Assert
            projectsRepoMock.Verify(m => m.Update(projectFromRepo.Object), Times.Once);
        }

        [Test]
        public void NotCallProjectRepoUpdateOnce_WhenProjectIsExistent()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectDto = new ProjectDto() { Id = Guid.NewGuid() };
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);
            Project projectFromRepo = null;
            projectsRepoMock.Setup(m => m.GetById(projectDto.Id)).Returns(projectFromRepo);

            //Act
            projectService.Update(projectDto);

            //Assert
            projectsRepoMock.Verify(m => m.Update(projectFromRepo), Times.Never);
        }

        [Test]
        public void ThrowArgumentNullException_WhenProjectDtoIsNull()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => projectService.Update(null));
        }
    }
}
