using CarManiacs.Business.Common;
using CarManiacs.Business.Models.Projects;
using CarManiacs.Business.Models.Stories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarManiacs.Business.Models.UnitTests.Users
{
    [TestFixture]
    public class RegularUser
    {
        [Test]
        public void Constructor_ShouldInitializeProjectsCollection()
        {
            //Arrange && Act
            var user = new Models.Users.RegularUser();

            //Assert
            Assert.That(user.Projects, Is.Not.Null.And.InstanceOf<ICollection<Project>>());
        }

        [Test]
        public void Id_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var id = Guid.NewGuid().ToString();

            //Act
            var user = new Models.Users.RegularUser() { Id = id };

            //Assert
            Assert.AreEqual(id, user.Id);
        }

        [Test]
        public void User_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var user = new Models.Users.User();

            //Act
            var regularUser = new Models.Users.RegularUser() { User = user };

            //Assert
            Assert.AreSame(user, regularUser.User);
            Assert.AreEqual(user.Id, regularUser.User.Id);
        }

        [TestCase("userTest123")]
        [TestCase("uuseerTeestFiirstNaamee")]
        public void FirstName_ShouldBeSetAndGottenCorrectly(string firstName)
        {
            //Arrange && Act
            var user = new Models.Users.RegularUser { FirstName = firstName };

            //Assert
            Assert.AreEqual(firstName, user.FirstName);
        }

        [Test]
        public void FirstName_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Users.RegularUser).GetProperty("FirstName");

            //Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void FirstName_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Users.RegularUser).GetProperty("FirstName");

            //Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMaxLength, maxLengthAttribute.Length);
        }

        [TestCase("userTest321")]
        [TestCase("uuseerTeestLaastNaamee")]
        public void LastName_ShouldBeSetAndGottenCorrectly(string lastName)
        {
            //Arrange && Act
            var user = new Models.Users.RegularUser { LastName = lastName };

            //Assert
            Assert.AreEqual(lastName, user.LastName);
        }

        [Test]
        public void LastName_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Users.RegularUser).GetProperty("LastName");

            //Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void LastName_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Users.RegularUser).GetProperty("LastName");

            //Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMaxLength, maxLengthAttribute.Length);
        }

        [TestCase(39)]
        [TestCase(19)]
        public void Age_ShouldBeSetAndGottenCorrectly(int age)
        {
            //Arrange && Act
            var user = new Models.Users.RegularUser { Age = age };

            //Assert
            Assert.AreEqual(age, user.Age);
        }

        [Test]
        public void Age_ShouldHaveCorrectRange()
        {
            //Arrange
            var nameProperty = typeof(Models.Users.RegularUser).GetProperty("Age");

            //Act
            var rangeAttribute = nameProperty.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.RangeAttribute), false)
                .Cast<System.ComponentModel.DataAnnotations.RangeAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.MinAge, rangeAttribute.Minimum);
            Assert.AreEqual(Constants.MaxAge, rangeAttribute.Maximum);
        }

        [TestCase("userTest321")]
        [TestCase("uuseerTeestCuureeentCaar")]
        public void CurrentCar_ShouldBeSetAndGottenCorrectly(string currentCar)
        {
            //Arrange && Act
            var user = new Models.Users.RegularUser { CurrentCar = currentCar };

            //Assert
            Assert.AreEqual(currentCar, user.CurrentCar);
        }

        [Test]
        public void CurrentCar_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Users.RegularUser).GetProperty("CurrentCar");

            //Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void CurrentCar_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Users.RegularUser).GetProperty("CurrentCar");

            //Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMaxLength, maxLengthAttribute.Length);
        }

        [TestCase("userTest321")]
        [TestCase("uuseerTeestFaavooriiteeCaar")]
        public void FavoriteCar_ShouldBeSetAndGottenCorrectly(string favoriteCar)
        {
            //Arrange && Act
            var user = new Models.Users.RegularUser { FavoriteCar = favoriteCar };

            //Assert
            Assert.AreEqual(favoriteCar, user.FavoriteCar);
        }

        [Test]
        public void FavoriteCar_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Users.RegularUser).GetProperty("FavoriteCar");

            //Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void FavoriteCar_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var nameProperty = typeof(Models.Users.RegularUser).GetProperty("FavoriteCar");

            //Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMaxLength, maxLengthAttribute.Length);
        }

        [TestCase("userTest321")]
        [TestCase("uuseerTeestEemaaiil")]
        public void Email_ShouldBeSetAndGottenCorrectly(string email)
        {
            //Arrange && Act
            var user = new Models.Users.RegularUser { Email = email };

            //Assert
            Assert.AreEqual(email, user.Email);
        }

        [Test]
        public void Email_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var emailProperty = typeof(Models.Users.RegularUser).GetProperty("Email");

            //Act
            var minLengthAttribute = emailProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void Email_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var emailProperty = typeof(Models.Users.RegularUser).GetProperty("Email");

            //Act
            var maxLengthAttribute = emailProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMaxLength, maxLengthAttribute.Length);
        }

        [TestCase("userTest321")]
        [TestCase("uuseerTeestEemaaiil")]
        public void AvatarUrl_ShouldBeSetAndGottenCorrectly(string avatarUrl)
        {
            //Arrange && Act
            var user = new Models.Users.RegularUser { AvatarUrl = avatarUrl };

            //Assert
            Assert.AreEqual(avatarUrl, user.AvatarUrl);
        }

        [Test]
        public void AvatarUrl_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var avatarUrlProperty = typeof(Models.Users.RegularUser).GetProperty("AvatarUrl");

            //Act
            var minLengthAttribute = avatarUrlProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.UrlMinLength, minLengthAttribute.Length);
        }

        [Test]
        public void AvatarUrl_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var avatarUrlProperty = typeof(Models.Users.RegularUser).GetProperty("AvatarUrl");

            //Act
            var maxLengthAttribute = avatarUrlProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.UrlMaxLength, maxLengthAttribute.Length);
        }

        [Test]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var isDeleted = true;

            //Act
            var user = new Models.Users.RegularUser { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(isDeleted, user.IsDeleted);
        }

        [Test]
        public void RegisterDate_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testDate = DateTime.Now;

            //Act
            var user = new Models.Users.RegularUser { RegisterDate = testDate };

            //Assert
            Assert.AreEqual(testDate, user.RegisterDate);
        }

        [Test]
        public void Projects_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var projects = new List<Project> { new Project() };

            //Act
            var user = new Models.Users.RegularUser() { Projects = projects };

            //Assert
            Assert.AreSame(projects[0], user.Projects.First());
            Assert.AreEqual(projects[0].Id, user.Projects.First().Id);
        }

        [Test]
        public void Stories_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var stories = new List<Story> { new Story() };

            //Act
            var user = new Models.Users.RegularUser() { Stories = stories };

            //Assert
            Assert.AreSame(stories[0], user.Stories.First());
            Assert.AreEqual(stories[0].Id, user.Stories.First().Id);
        }
    }
}
