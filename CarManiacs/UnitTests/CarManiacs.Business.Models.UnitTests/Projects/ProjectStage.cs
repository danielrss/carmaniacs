using CarManiacs.Business.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarManiacs.Business.Models.UnitTests.Projects
{
    [TestFixture]
    public class ProjectStage
    {
        [Test]
        public void Constructor_ShouldInitializeImageUrlsCollection()
        {
            //Arrange && Act
            var projectStage = new Models.Projects.ProjectStage();

            //Assert
            Assert.That(
                projectStage.ImageUrls, 
                Is.Not.Null.And.InstanceOf<ICollection<Models.Projects.ProjectStageImageUrl>>());
        }

        [TestCase("f238acd3-7fed-4563-9c58-17653de7de55")]
        [TestCase("a707a20e-fb2b-40db-a47b-2292e720b248")]
        public void Id_ShouldBeSetAndGottenCorrectly(string testId)
        {
            //Arrange && Act
            var projectStage = new Models.Projects.Project { Id = Guid.Parse(testId) };

            //Assert
            Assert.AreEqual(testId, projectStage.Id.ToString());
        }

        [TestCase("projectStageTest123")]
        [TestCase("projectStaageeTeestTiitlee")]
        public void Title_ShouldBeSetAndGottenCorrectly(string testTitle)
        {
            //Arrange && Act
            var projectStage = new Models.Projects.ProjectStage { Title = testTitle };

            //Assert
            Assert.AreEqual(testTitle, projectStage.Title);
        }

        [Test]
        public void Title_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Projects.ProjectStage).GetProperty("Title");

            //Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.TitleMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void Title_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Projects.ProjectStage).GetProperty("Title");

            //Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.TitleMaxLength, maxLengthAttribute.Length);
        }

        [TestCase("projectStageDescriptionTest123")]
        [TestCase("projectStaageeTeestDeescriiptiioon")]
        public void Description_ShouldBeSetAndGottenCorrectly(string testDescription)
        {
            //Arrange && Act
            var projectStage = new Models.Projects.ProjectStage { Description = testDescription };

            //Assert
            Assert.AreEqual(testDescription, projectStage.Description);
        }

        [Test]
        public void Description_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var descriptionProperty = typeof(Models.Projects.ProjectStage).GetProperty("Description");

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
            var descriptionProperty = typeof(Models.Projects.ProjectStage).GetProperty("Description");

            //Act
            var maxLengthAttribute = descriptionProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.ProjectDescriptionMaxLength, maxLengthAttribute.Length);
        }

        [Test]
        public void ImageUrls_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var imageUrls = new List<Models.Projects.ProjectStageImageUrl> { new Models.Projects.ProjectStageImageUrl() };

            //Act
            var projectStage = new Models.Projects.ProjectStage { ImageUrls = imageUrls };

            //Assert
            Assert.AreSame(imageUrls[0], projectStage.ImageUrls.First());
            Assert.AreEqual(imageUrls[0].Id, projectStage.ImageUrls.First().Id);
        }

        [Test]
        public void Project_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var project = new Models.Projects.Project();

            //Act
            var projectStage = new Models.Projects.ProjectStage() { Project = project };

            //Assert
            Assert.AreSame(project, projectStage.Project);
            Assert.AreEqual(project.Id, projectStage.Project.Id);
        }

        [Test]
        public void ProjectId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid();

            //Act
            var projectStage = new Models.Projects.ProjectStage { ProjectId = testId };

            //Assert
            Assert.AreEqual(testId, projectStage.ProjectId);
        }
    }
}
