using CarManiacs.Business.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarManiacs.Business.Models.UnitTests.Locations
{
    [TestFixture]
    public class Country
    {
        [Test]
        public void Constructor_IdShouldBeSetCorrectly()
        {
            //Arrange & Act
            var country = new Models.Locations.Country();

            //Assert
            Assert.AreNotEqual(Guid.Empty, country.Id);
        }

        [Test]
        public void Constructor_ShouldInitializeCitiesCollection()
        {
            //Arrange && Act
            var country = new Models.Locations.Country();

            //Assert
            Assert.That(country.Cities, Is.Not.Null.And.InstanceOf<ICollection<Models.Locations.City>>());
        }

        [TestCase("countryTest123")]
        [TestCase("countryyTeestNaamee")]
        public void Name_ShouldBeSetAndGottenCorrectly(string testName)
        {
            //Arrange && Act
            var country = new Models.Locations.Country { Name = testName };

            //Assert
            Assert.AreEqual(testName, country.Name);
        }

        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Locations.Country).GetProperty("Name");

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
            var nameProperty = typeof(Models.Locations.Country).GetProperty("Name");

            //Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMaxLength, maxLengthAttribute.Length);
        }

        [Test]
        public void Cities_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var cities = new List<Models.Locations.City> { new Models.Locations.City() };

            //Act
            var country = new Models.Locations.Country { Cities = cities };

            //Assert
            Assert.AreSame(cities[0], country.Cities.First());
            Assert.AreEqual(cities[0].Id, country.Cities.First().Id);
        }
    }
}
