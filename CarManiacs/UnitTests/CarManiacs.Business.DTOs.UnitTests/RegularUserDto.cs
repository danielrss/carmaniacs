using NUnit.Framework;
using System;

namespace CarManiacs.Business.DTOs.UnitTests
{
    [TestFixture]
    public class RegularUserDto
    {
        [Test]
        public void Id_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var id = Guid.NewGuid().ToString();

            //Act
            var user = new DTOs.RegularUserDto() { Id = id };

            //Assert
            Assert.AreEqual(id, user.Id);
        }

        [Test]
        public void FirstName_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var firstName = "totallyRandomFirstNaaameee";

            //Act
            var user = new DTOs.RegularUserDto() { FirstName = firstName };

            //Assert
            Assert.AreEqual(firstName, user.FirstName);
        }

        [Test]
        public void LastName_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var lastName = "totallyRandomLastNaaameee";

            //Act
            var user = new DTOs.RegularUserDto() { LastName = lastName };

            //Assert
            Assert.AreEqual(lastName, user.LastName);
        }
    }
}
