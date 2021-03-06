﻿using NUnit.Framework;
using System;

namespace CarManiacs.Business.Models.UnitTests.Users
{
    [TestFixture]
    public class Admin
    {
        [Test]
        public void Id_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var id = Guid.NewGuid().ToString();

            //Act
            var admin = new Models.Users.Admin() { Id = id };

            //Assert
            Assert.AreEqual(id, admin.Id);
        }

        [Test]
        public void User_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var user = new Models.Users.User();

            //Act
            var admin = new Models.Users.Admin() { User = user };

            //Assert
            Assert.AreSame(user, admin.User);
            Assert.AreEqual(user.Id, admin.User.Id);
        }

        [Test]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var isDeleted = true;

            //Act
            var user = new Models.Users.Admin { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(isDeleted, user.IsDeleted);
        }

        [Test]
        public void RegisterDate_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testDate = DateTime.Now;

            //Act
            var user = new Models.Users.Admin { RegisterDate = testDate };

            //Assert
            Assert.AreEqual(testDate, user.RegisterDate);
        }
    }
}
