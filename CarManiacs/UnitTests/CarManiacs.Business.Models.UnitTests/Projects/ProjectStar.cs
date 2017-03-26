using NUnit.Framework;
using System;

namespace CarManiacs.Business.Models.UnitTests.Projects
{
    [TestFixture]
    public class ProjectStar
    {
        [TestCase("f238acd3-7fed-4563-9c58-17653de7de55")]
        [TestCase("a707a20e-fb2b-40db-a47b-2292e720b248")]
        public void Id_ShouldBeSetAndGottenCorrectly(string testId)
        {
            //Arrange && Act
            var projectStar = new Models.Projects.ProjectStar { Id = Guid.Parse(testId) };

            //Assert
            Assert.AreEqual(testId, projectStar.Id.ToString());
        }

        [Test]
        public void Project_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var project = new Models.Projects.Project();

            //Act
            var projectStar = new Models.Projects.ProjectStar() { Project = project };

            //Assert
            Assert.AreSame(project, projectStar.Project);
        }

        [Test]
        public void ProjectId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid();

            //Act
            var projectStar = new Models.Projects.ProjectStar { ProjectId = testId };

            //Assert
            Assert.AreEqual(testId, projectStar.ProjectId);
        }

        [Test]
        public void User_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var user = new Models.Users.RegularUser();

            //Act
            var projectStar = new Models.Projects.ProjectStar() { User = user };

            //Assert
            Assert.AreSame(user, projectStar.User);
        }

        [Test]
        public void UserId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid().ToString();

            //Act
            var projectStar = new Models.Projects.ProjectStar { UserId = testId };

            //Assert
            Assert.AreEqual(testId, projectStar.UserId);
        }
    }
}
