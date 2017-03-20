using CarManiacs.Business.Common;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarManiacs.Business.Models.UnitTests.Projects
{
    [TestFixture]
    public class ProjectStageImageUrl
    {
        [Test]
        public void Constructor_IdShouldBeSetCorrectly()
        {
            //Arrange & Act
            var imageUrl = new Models.Projects.ProjectStageImageUrl();

            //Assert
            Assert.AreNotEqual(Guid.Empty, imageUrl.Id);
        }

        [TestCase("imageUrlTest123")]
        [TestCase("iimaageeUUrl")]
        public void Url_ShouldBeSetAndGottenCorrectly(string testUrl)
        {
            //Arrange && Act
            var imageUrl = new Models.Projects.ProjectStageImageUrl { Url = testUrl };

            //Assert
            Assert.AreEqual(testUrl, imageUrl.Url);
        }

        [Test]
        public void Url_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Projects.ProjectStageImageUrl).GetProperty("Url");

            //Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.UrlMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void Url_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Projects.ProjectStageImageUrl).GetProperty("Url");

            //Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.UrlMaxLength, maxLengthAttribute.Length);
        }

        [Test]
        public void ProjectStage_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var projectStage = new Models.Projects.ProjectStage();

            //Act
            var imageUrl = new Models.Projects.ProjectStageImageUrl() { ProjectStage = projectStage };

            //Assert
            Assert.AreSame(projectStage, imageUrl.ProjectStage);
            Assert.AreEqual(projectStage.Id, imageUrl.ProjectStage.Id);
        }

        [Test]
        public void ProjectStageId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid();

            //Act
            var imageUrl = new Models.Projects.ProjectStageImageUrl { ProjectStageId = testId };

            //Assert
            Assert.AreEqual(testId, imageUrl.ProjectStageId);
        }
    }
}
