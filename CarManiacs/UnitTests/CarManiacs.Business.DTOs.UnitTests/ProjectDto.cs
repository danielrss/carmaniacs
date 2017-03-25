using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManiacs.Business.DTOs.UnitTests
{
    [TestFixture]
    public class ProjectDto
    {
        [Test]
        public void Id_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            var project = new DTOs.ProjectDto() { Id = id };

            //Assert
            Assert.AreEqual(id, project.Id);
        }

        [Test]
        public void Title_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var title = "someTootaallyyRandomTitle";

            //Act
            var project = new DTOs.ProjectDto() { Title = title };

            //Assert
            Assert.AreEqual(title, project.Title);
        }

        [Test]
        public void Description_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var description = "someTootaallyyRandomDescription";

            //Act
            var project = new DTOs.ProjectDto() { Description = description };

            //Assert
            Assert.AreEqual(description, project.Description);
        }
    }
}
