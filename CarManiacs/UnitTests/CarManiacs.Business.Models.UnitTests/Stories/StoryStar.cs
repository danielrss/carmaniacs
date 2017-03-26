using NUnit.Framework;
using System;

namespace CarManiacs.Business.Models.UnitTests.Stories
{
    [TestFixture]
    public class StoryStar
    {
        [TestCase("f238acd3-7fed-4563-9c58-17653de7de55")]
        [TestCase("a707a20e-fb2b-40db-a47b-2292e720b248")]
        public void Id_ShouldBeSetAndGottenCorrectly(string testId)
        {
            //Arrange && Act
            var storyStar = new Models.Stories.StoryStar { Id = Guid.Parse(testId) };

            //Assert
            Assert.AreEqual(testId, storyStar.Id.ToString());
        }

        [Test]
        public void Story_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var story = new Models.Stories.Story();

            //Act
            var storyStar = new Models.Stories.StoryStar() { Story = story };

            //Assert
            Assert.AreSame(story, storyStar.Story);
        }

        [Test]
        public void StoryId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid();

            //Act
            var storyStar = new Models.Stories.StoryStar { StoryId = testId };

            //Assert
            Assert.AreEqual(testId, storyStar.StoryId);
        }

        [Test]
        public void User_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var user = new Models.Users.RegularUser();

            //Act
            var storyStar = new Models.Stories.StoryStar() { User = user };

            //Assert
            Assert.AreSame(user, storyStar.User);
        }

        [Test]
        public void UserId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid().ToString();

            //Act
            var storyStar = new Models.Stories.StoryStar { UserId = testId };

            //Assert
            Assert.AreEqual(testId, storyStar.UserId);
        }
    }
}
