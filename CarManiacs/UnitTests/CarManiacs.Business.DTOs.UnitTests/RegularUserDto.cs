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

        [Test]
        public void Age_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var age = 21;

            //Act
            var user = new DTOs.RegularUserDto() { Age = age };

            //Assert
            Assert.AreEqual(age, user.Age);
        }

        [Test]
        public void CurrentCar_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var currentCar = "totallyRandomCuurreentCaar";

            //Act
            var user = new DTOs.RegularUserDto() { CurrentCar = currentCar };

            //Assert
            Assert.AreEqual(currentCar, user.CurrentCar);
        }

        [Test]
        public void FavoriteCar_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var favoriteCar = "totallyRandomfaavooriiteeCaar";

            //Act
            var user = new DTOs.RegularUserDto() { FavoriteCar = favoriteCar };

            //Assert
            Assert.AreEqual(favoriteCar, user.FavoriteCar);
        }
    }
}
