using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Projects;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.ProjectService
{
    [TestFixture]
    public class Comment_Should
    {
        [Test]
        public void ThrowArgumentException_WhenProjectIdIsEmpty()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => projectService.Comment(Guid.Empty, "raandoomStriing1", "raandoomStriing2"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCommentIsNull()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => projectService.Comment(Guid.NewGuid(), "raandoomStriing1", null));
        }

        [Test]
        public void ThrowArgumentException_WhenUserIdIsEmpty()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => projectService.Comment(Guid.NewGuid(), "raandoomStriing1", string.Empty));
        }
    }
}
