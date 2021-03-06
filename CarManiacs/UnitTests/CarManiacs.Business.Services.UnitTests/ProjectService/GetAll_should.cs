﻿using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Projects;
using Moq;
using NUnit.Framework;

namespace CarManiacs.Business.Services.UnitTests.ProjectService
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void CallProjectRepoAllOnce()
        {
            //Arrange
            var projectsRepoMock = new Mock<IEfRepository<Project>>();
            var projectStarsRepoMock = new Mock<IEfRepository<ProjectStar>>();
            var projectService = new Services.ProjectService(projectsRepoMock.Object, projectStarsRepoMock.Object);

            //Act
            projectService.GetAll();

            //Assert
            projectsRepoMock.Verify(m => m.All, Times.Once);
        }
    }
}
