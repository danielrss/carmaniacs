using CarManiacs.Business.Common;

using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarManiacs.Business.Models.UnitTests.Locations
{
    [TestFixture]
    public class City
    {
        [Test]
        public void Constructor_IdShouldBeSetCorrectly()
        {
            //Arrange & Act
            var city = new Models.Locations.City();

            //Assert
            Assert.AreNotEqual(Guid.Empty, city.Id);
        }

        [TestCase("cityTest123")]
        [TestCase("ciityyTeestNaamee")]
        public void Name_ShouldBeSetAndGottenCorrectly(string testName)
        {
            //Arrange && Act
            var city = new Models.Locations.City { Name = testName };

            //Assert
            Assert.AreEqual(testName, city.Name);
        }

        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Locations.City).GetProperty("Name");

            //Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Locations.City).GetProperty("Name");

            //Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMaxLength, maxLengthAttribute.Length);
        }

        [Test]
        public void Country_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var country = new Models.Locations.Country();

            //Act
            var city = new Models.Locations.City() { Country = country };

            //Assert
            Assert.AreSame(country, city.Country);
            Assert.AreEqual(country.Id, city.Country.Id);
        }

        [Test]
        public void CountryId_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testId = Guid.NewGuid();

            //Act
            var city = new Models.Locations.City { CountryId = testId };

            //Assert
            Assert.AreEqual(testId, city.CountryId);
        }
    }
}
