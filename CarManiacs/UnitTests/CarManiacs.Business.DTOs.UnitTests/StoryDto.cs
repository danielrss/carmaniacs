using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManiacs.Business.DTOs.UnitTests
{
    [TestFixture]
    public class StoryDto
    {
        [Test]
        public void Id_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            var story = new DTOs.StoryDto() { Id = id };

            //Assert
            Assert.AreEqual(id, story.Id);
        }

        [Test]
        public void Title_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var title = "someTootaallyyRandomTitle";

            //Act
            var story = new DTOs.StoryDto() { Title = title };

            //Assert
            Assert.AreEqual(title, story.Title);
        }

        [Test]
        public void Content_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var content = "someTootaallyyRandomContent";

            //Act
            var story = new DTOs.StoryDto() { Content = content };

            //Assert
            Assert.AreEqual(content, story.Content);
        }
    }
}
