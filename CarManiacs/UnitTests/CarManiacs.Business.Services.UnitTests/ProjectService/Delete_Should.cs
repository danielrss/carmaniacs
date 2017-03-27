using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Projects;
using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.ProjectService
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void CallProjectRepoUpdateOnce_WhenProjectIsExistent()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);
            var projectFromRepo = new Mock<Project>();
            var projectId = Guid.NewGuid();
            projectsRepoMock.Setup(m => m.GetById(projectId)).Returns(projectFromRepo.Object);

            //Act
            projectService.Delete(projectId);

            //Assert
            projectsRepoMock.Verify(m => m.Update(projectFromRepo.Object), Times.Once);
        }

        [Test]
        public void NotCallProjectRepoUpdate_WhenProjectIsNonExistent()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectId = Guid.NewGuid();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);
            Project projectFromRepo = null;
            projectsRepoMock.Setup(m => m.GetById(projectId)).Returns(projectFromRepo);

            //Act
            projectService.Delete(projectId);

            //Assert
            projectsRepoMock.Verify(m => m.Update(projectFromRepo), Times.Never);
        }

        [Test]
        public void ThrowArgumentException_WhenProjectIdIsEmpty()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => projectService.Delete(Guid.Empty));
        }
    }
}
