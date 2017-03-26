using NUnit.Framework;
using System;

namespace CarManiacs.Business.Models.UnitTests.Projects
{
    [TestFixture]
    public class ProjectComment
    {
        [TestCase("f238acd3-7fed-4563-9c58-17653de7de55")]
        [TestCase("a707a20e-fb2b-40db-a47b-2292e720b248")]
        public void Id_ShouldBeSetAndGottenCorrectly(string testId)
        {
            //Arrange && Act
            var projectComment = new Models.Projects.ProjectComment { Id = Guid.Parse(testId) };

            //Assert
            Assert.AreEqual(testId, projectComment.Id.ToString());
        }

        [TestCase("testConteeeent")]
        [TestCase("projectCommentTest123")]
        public void Content_ShouldBeSetAndGottenCorrectly(string testContent)
        {
            //Arrange && Act
            var projectComment = new Models.Projects.ProjectComment { Content = testContent };

            //Assert
            Assert.AreEqual(testContent, projectComment.Content);
        }

        [Test]
        public void Project_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var project = new Models.Projects.Project();

            //Act
            var projectComment = new Models.Projects.ProjectComment() { Project = project };

            //Assert
            Assert.AreSame(project, projectComment.Project);
        }

        [Test]
        public void ProjectId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid();

            //Act
            var projectComment = new Models.Projects.ProjectComment { ProjectId = testId };

            //Assert
            Assert.AreEqual(testId, projectComment.ProjectId);
        }

        [Test]
        public void User_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var user = new Models.Users.RegularUser();

            //Act
            var projectComment = new Models.Projects.ProjectComment() { User = user };

            //Assert
            Assert.AreSame(user, projectComment.User);
        }

        [Test]
        public void UserId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid().ToString();

            //Act
            var projectComment = new Models.Projects.ProjectComment { UserId = testId };

            //Assert
            Assert.AreEqual(testId, projectComment.UserId);
        }
    }
}
