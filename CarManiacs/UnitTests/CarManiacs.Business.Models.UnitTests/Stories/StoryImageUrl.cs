using CarManiacs.Business.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManiacs.Business.Models.UnitTests.Stories
{
    [TestFixture]
    public class StoryImageUrl
    {
        [TestCase("f238acd3-7fed-4563-9c58-17653de7de55")]
        [TestCase("a707a20e-fb2b-40db-a47b-2292e720b248")]
        public void Id_ShouldBeSetAndGottenCorrectly(string testId)
        {
            //Arrange && Act
            var imageUrl = new Models.Stories.StoryImageUrl { Id = Guid.Parse(testId) };

            //Assert
            Assert.AreEqual(testId, imageUrl.Id.ToString());
        }

        [TestCase("imageUrlTest123")]
        [TestCase("iimaageeUUrl")]
        public void Url_ShouldBeSetAndGottenCorrectly(string testUrl)
        {
            //Arrange && Act
            var imageUrl = new Models.Stories.StoryImageUrl { Url = testUrl };

            //Assert
            Assert.AreEqual(testUrl, imageUrl.Url);
        }

        [Test]
        public void Url_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Stories.StoryImageUrl).GetProperty("Url");

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
            var nameProperty = typeof(Models.Stories.StoryImageUrl).GetProperty("Url");

            //Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.UrlMaxLength, maxLengthAttribute.Length);
        }

        [Test]
        public void Story_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var story = new Models.Stories.Story();

            //Act
            var imageUrl = new Models.Stories.StoryImageUrl { Story = story };

            //Assert
            Assert.AreSame(story, imageUrl.Story);
        }

        [Test]
        public void StoryId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid();

            //Act
            var imageUrl = new Models.Stories.StoryImageUrl { StoryId = testId };

            //Assert
            Assert.AreEqual(testId, imageUrl.StoryId);
        }
    }
}
