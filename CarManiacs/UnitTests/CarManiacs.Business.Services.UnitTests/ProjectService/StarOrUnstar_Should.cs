using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Projects;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.ProjectService
{
    [TestFixture]
    public class StarOrUnstar_Should
    {
        [Test]
        public void ThrowArgumentException_WhenProjectIdIsEmpty()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => projectService.StarOrUnstar(Guid.Empty, "raandoomStriing2"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => projectService.StarOrUnstar(Guid.NewGuid(), null));
        }

        [Test]
        public void ThrowArgumentException_WhenUserIdIsEmpty()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => projectService.StarOrUnstar(Guid.NewGuid(), string.Empty));
        }
    }
}
