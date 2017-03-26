using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Projects;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.ProjectService
{
    [TestFixture]
    public class HasUserStarred_Should
    {
        [Test]
        public void ReturnFalse_WhenProjectIsNonExistent()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectId = Guid.NewGuid();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);
            Project projectFromRepo = null;
            projectsRepoMock.Setup(m => m.GetById(projectId)).Returns(projectFromRepo);

            //Act && Assert
            Assert.IsFalse(projectService.HasUserStarred(projectId, "tootaallyyRandomImageUrl2"));
        }

        [Test]
        public void ThrowArgumentException_WhenProjectIdIsEmpty()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => projectService.HasUserStarred(Guid.Empty, "raandoomStriing2"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => projectService.HasUserStarred(Guid.NewGuid(), null));
        }

        [Test]
        public void ThrowArgumentException_WhenUserIdIsEmpty()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => projectService.HasUserStarred(Guid.NewGuid(), string.Empty));
        }
    }
}
