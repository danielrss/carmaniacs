using CarManiacs.Business.Models.Projects;

using NUnit.Framework;
using System;
using System.Collections.Generic;
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
    }
}
