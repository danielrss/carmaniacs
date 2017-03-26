using CarManiacs.Business.Common;
using CarManiacs.Business.Models.Users;

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarManiacs.Business.Models.UnitTests.Stories
{
    [TestFixture]
    public class Story
    {
        [Test]
        public void Constructor_ShouldInitializeCollections()
        {
            //Arrange && Act
            var story = new Models.Stories.Story();

            //Assert
            Assert.That(
                story.ImageUrls,
                Is.Not.Null.And.InstanceOf<ICollection<Models.Stories.StoryImageUrl>>());
            Assert.That(
                story.Stars,
                Is.Not.Null.And.InstanceOf<ICollection<Models.Stories.StoryStar>>());
            Assert.That(
                story.Comments,
                Is.Not.Null.And.InstanceOf<ICollection<Models.Stories.StoryComment>>());
        }

        [TestCase("f238acd3-7fed-4563-9c58-17653de7de55")]
        [TestCase("a707a20e-fb2b-40db-a47b-2292e720b248")]
        public void Id_ShouldBeSetAndGottenCorrectly(string testId)
        {
            //Arrange && Act
            var story = new Models.Stories.Story { Id = Guid.Parse(testId) };

            //Assert
            Assert.AreEqual(testId, story.Id.ToString());
        }

        [TestCase("storyTest123")]
        [TestCase("storyTeestTiitlee")]
        public void Title_ShouldBeSetAndGottenCorrectly(string testTitle)
        {
            //Arrange && Act
            var story = new Models.Stories.Story { Title = testTitle };

            //Assert
            Assert.AreEqual(testTitle, story.Title);
        }

        [Test]
        public void Title_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var titleProperty = typeof(Models.Stories.Story).GetProperty("Title");

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
            var titleProperty = typeof(Models.Stories.Story).GetProperty("Title");

            //Act
            var maxLengthAttribute = titleProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.TitleMaxLength, maxLengthAttribute.Length);
        }

        [TestCase("storyContentTest123")]
        [TestCase("storyTeestCoonteent")]
        public void Content_ShouldBeSetAndGottenCorrectly(string testContent)
        {
            //Arrange && Act
            var story = new Models.Stories.Story { Content = testContent };

            //Assert
            Assert.AreEqual(testContent, story.Content);
        }

        [Test]
        public void Content_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var contentProperty = typeof(Models.Stories.Story).GetProperty("Content");

            //Act
            var minLengthAttribute = contentProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.StoryContentMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void Content_ShouldHaveCorrectMaxLength()
        {
            //contentProperty
            var contentProperty = typeof(Models.Stories.Story).GetProperty("Content");

            //Act
            var maxLengthAttribute = contentProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.StoryContentMaxLength, maxLengthAttribute.Length);
        }

        [Test]
        public void PublishDate_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testDate = DateTime.Now;

            //Act
            var story = new Models.Stories.Story() { PublishDate = testDate };

            //Assert
            Assert.AreEqual(testDate, story.PublishDate);
        }

        [Test]
        public void User_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var user = new RegularUser() { Id = Guid.NewGuid().ToString() };

            //Act
            var story = new Models.Stories.Story() { User = user };

            //Assert
            Assert.AreSame(user, story.User);
            Assert.AreEqual(user.Id, story.User.Id);
        }

        [Test]
        public void UserId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid().ToString();

            //Act
            var story = new Models.Stories.Story { UserId = testId };

            //Assert
            Assert.AreEqual(testId, story.UserId);
        }

        [Test]
        public void ImageUrls_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var imageUrls = new List<Models.Stories.StoryImageUrl> { new Models.Stories.StoryImageUrl() };

            //Act
            var story = new Models.Stories.Story { ImageUrls = imageUrls };

            //Assert
            Assert.AreSame(imageUrls[0], story.ImageUrls.First());
        }

        [Test]
        public void Stars_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var stars = new List<Models.Stories.StoryStar> { new Models.Stories.StoryStar() };

            //Act
            var story = new Models.Stories.Story { Stars = stars };

            //Assert
            Assert.AreSame(stars[0], story.Stars.First());
        }

        [Test]
        public void Comments_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var comments = new List<Models.Stories.StoryComment> { new Models.Stories.StoryComment() };

            //Act
            var story = new Models.Stories.Story { Comments = comments };

            //Assert
            Assert.AreSame(comments[0], story.Comments.First());
        }
    }
}
