using CarManiacs.Business.Common;
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
        public void Constructor_ShouldInitializeStagesCollection()
        {
            //Arrange && Act
            var project = new Models.Projects.Project();

            //Assert
            Assert.That(
                project.Stages,
                Is.Not.Null.And.InstanceOf<ICollection<Models.Projects.ProjectStage>>());
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

        [Test]
        public void Stages_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var stages = new List<Models.Projects.ProjectStage> { new Models.Projects.ProjectStage() };

            //Act
            var project = new Models.Projects.Project { Stages = stages };

            //Assert
            Assert.AreSame(stages[0], project.Stages.First());
            Assert.AreEqual(stages[0].Id, project.Stages.First().Id);
        }
    }
}
