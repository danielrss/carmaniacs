using CarManiacs.Business.Common;
using CarManiacs.Business.Models.Users;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarManiacs.Business.Models.UnitTests.Projects
{
    [TestFixture]
    public class Project
    {
        [Test]
        public void Constructor_ShouldInitializeCollections()
        {
            //Arrange && Act
            var project = new Models.Projects.Project();

            //Assert
            Assert.That(
                project.Stages,
                Is.Not.Null.And.InstanceOf<ICollection<Models.Projects.ProjectStage>>());
            Assert.That(
                project.Stars,
                Is.Not.Null.And.InstanceOf<ICollection<Models.Projects.ProjectStar>>());
            Assert.That(
                project.Comments,
                Is.Not.Null.And.InstanceOf<ICollection<Models.Projects.ProjectComment>>());
        }

        [TestCase("f238acd3-7fed-4563-9c58-17653de7de55")]
        [TestCase("a707a20e-fb2b-40db-a47b-2292e720b248")]
        public void Id_ShouldBeSetAndGottenCorrectly(string testId)
        {
            //Arrange && Act
            var project = new Models.Projects.Project { Id = Guid.Parse(testId) };

            //Assert
            Assert.AreEqual(testId, project.Id.ToString());
        }

        [TestCase("projectTest123")]
        [TestCase("projectTeestTiitlee")]
        public void Title_ShouldBeSetAndGottenCorrectly(string testTitle)
        {
            //Arrange && Act
            var project = new Models.Projects.Project { Title = testTitle };

            //Assert
            Assert.AreEqual(testTitle, project.Title);
        }

        [Test]
        public void Title_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var titleProperty = typeof(Models.Projects.Project).GetProperty("Title");

            //Act
            var minLengthAttribute = titleProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.TitleMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void Title_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var titleProperty = typeof(Models.Projects.Project).GetProperty("Title");

            //Act
            var maxLengthAttribute = titleProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.TitleMaxLength, maxLengthAttribute.Length);
        }

        [TestCase("projectDescriptionTest123")]
        [TestCase("projectTeestDeescriiptiioon")]
        public void Description_ShouldBeSetAndGottenCorrectly(string testDescription)
        {
            //Arrange && Act
            var project = new Models.Projects.Project { Description = testDescription };

            //Assert
            Assert.AreEqual(testDescription, project.Description);
        }

        [Test]
        public void Description_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var descriptionProperty = typeof(Models.Projects.Project).GetProperty("Description");

            //Act
            var minLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.ProjectDescriptionMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void Description_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var descriptionProperty = typeof(Models.Projects.Project).GetProperty("Description");

            //Act
            var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.ProjectDescriptionMaxLength, maxLengthAttribute.Length);
        }

        [Test]
        public void User_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var user = new RegularUser() { Id = Guid.NewGuid().ToString() };

            //Act
            var project = new Models.Projects.Project() { User = user };

            //Assert
            Assert.AreSame(user, project.User);
            Assert.AreEqual(user.Id, project.User.Id);
        }

        [Test]
        public void UserId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid().ToString();

            //Act
            var project = new Models.Projects.Project { UserId = testId };

            //Assert
            Assert.AreEqual(testId, project.UserId);
        }

        [Test]
        public void Stages_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var stages = new List<Models.Projects.ProjectStage> { new Models.Projects.ProjectStage() };

            //Act
            var project = new Models.Projects.Project { Stages = stages };

            //Assert
            Assert.AreSame(stages[0], project.Stages.First());
        }

        [Test]
        public void Stars_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var stars = new List<Models.Projects.ProjectStar> { new Models.Projects.ProjectStar() };

            //Act
            var project = new Models.Projects.Project { Stars = stars };

            //Assert
            Assert.AreSame(stars[0], project.Stars.First());
        }

        [Test]
        public void Comments_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var comments = new List<Models.Projects.ProjectComment> { new Models.Projects.ProjectComment() };

            //Act
            var project = new Models.Projects.Project { Comments = comments };

            //Assert
            Assert.AreSame(comments[0], project.Comments.First());
        }
    }
}
