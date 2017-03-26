using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Projects;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.ProjectService
{
    [TestFixture]
    public class UpdateImageUrl_Should
    {
        [Test]
        public void CallProjectRepoUpdateOnce_WhenUserIsExistent()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object);
            var projectFromRepo = new Mock<Project>();
            var projectId = Guid.NewGuid();
            projectsRepoMock.Setup(m => m.GetById(projectId)).Returns(projectFromRepo.Object);

            //Act
            projectService.UpdateImageUrl(projectId, "tootaallyyRandomImageUrl");

            //Assert
            projectsRepoMock.Verify(m => m.Update(projectFromRepo.Object), Times.Once);
        }

        [Test]
        public void NotCallProjectRepoUpdate_WhenUserIsNonExistent()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectId = Guid.NewGuid();
            var projectService = new Services.ProjectService(projectsRepoMock.Object);
            Project projectFromRepo = null;
            projectsRepoMock.Setup(m => m.GetById(projectId)).Returns(projectFromRepo);

            //Act
            projectService.UpdateImageUrl(projectId, "tootaallyyRandomImageUrl2");

            //Assert
            projectsRepoMock.Verify(m => m.Update(projectFromRepo), Times.Never);
        }

        [Test]
        public void ThrowArgumentException_WhenProjectIdIsEmpty()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => projectService.UpdateImageUrl(Guid.Empty, "raandoomStriing2"));
        }
    }
}
