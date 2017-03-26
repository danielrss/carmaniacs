using NUnit.Framework;
using System;

namespace CarManiacs.Business.Models.UnitTests.Stories
{
    [TestFixture]
    public class StoryComment
    {
        [TestCase("f238acd3-7fed-4563-9c58-17653de7de55")]
        [TestCase("a707a20e-fb2b-40db-a47b-2292e720b248")]
        public void Id_ShouldBeSetAndGottenCorrectly(string testId)
        {
            //Arrange && Act
            var storyComment = new Models.Stories.StoryComment { Id = Guid.Parse(testId) };

            //Assert
            Assert.AreEqual(testId, storyComment.Id.ToString());
        }

        [TestCase("testConteeeent")]
        [TestCase("storyCommentTest123")]
        public void Content_ShouldBeSetAndGottenCorrectly(string testContent)
        {
            //Arrange && Act
            var storyComment = new Models.Stories.StoryComment { Content = testContent };

            //Assert
            Assert.AreEqual(testContent, storyComment.Content);
        }

        [Test]
        public void PublishDate_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testDate = DateTime.Now;

            //Act
            var storyComment = new Models.Stories.StoryComment() { PublishDate = testDate };

            //Assert
            Assert.AreEqual(testDate, storyComment.PublishDate);
        }

        [Test]
        public void Story_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var story = new Models.Stories.Story();

            //Act
            var storyComment = new Models.Stories.StoryComment() { Story = story };

            //Assert
            Assert.AreSame(story, storyComment.Story);
        }

        [Test]
        public void StoryId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid();

            //Act
            var storyComment = new Models.Stories.StoryComment { StoryId = testId };

            //Assert
            Assert.AreEqual(testId, storyComment.StoryId);
        }

        [Test]
        public void User_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var user = new Models.Users.RegularUser();

            //Act
            var storyComment = new Models.Stories.StoryComment() { User = user };

            //Assert
            Assert.AreSame(user, storyComment.User);
        }

        [Test]
        public void UserId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid().ToString();

            //Act
            var storyComment = new Models.Stories.StoryComment { UserId = testId };

            //Assert
            Assert.AreEqual(testId, storyComment.UserId);
        }
    }
}
