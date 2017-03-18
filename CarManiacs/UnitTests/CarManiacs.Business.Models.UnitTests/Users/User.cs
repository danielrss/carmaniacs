using NUnit.Framework;
using System;

namespace CarManiacs.Business.Models.UnitTests.Users
{
    [TestFixture]
    public class User
    {
        [Test]
        public void ParameterlessConstructor_ShouldSetRegisterDateCorrectly()
        {
            //Arrange && Act
            var user = new Models.Users.User();

            //Assert
            Assert.That(user.RegisterDate, Is.AtLeast(DateTime.Now.AddSeconds(-1)));
            Assert.That(user.RegisterDate, Is.AtMost(DateTime.Now));
        }

        [Test]
        public void UsernameConstructor_ShouldSetRegisterDateCorrectly()
        {
            //Arrange && Act
            var user = new Models.Users.User("someRandomUsername");

            //Assert
            Assert.That(user.RegisterDate, Is.AtLeast(DateTime.Now.AddSeconds(-1)));
            Assert.That(user.RegisterDate, Is.AtMost(DateTime.Now));
        }

        [TestCase("uuseerTeest123")]
        [TestCase("someRandomAvatarUrl")]
        public void AvatarUrl_ShouldBeSetAndGottenCorrectly(string url)
        {
            //Arrange & Act
            var user = new Models.Users.User() { AvatarUrl = url };

            //Assert
            Assert.AreEqual(url, user.AvatarUrl);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_ShouldBeSetAndGottenCorrectly(bool isDeleted)
        {
            //Arrange & Act
            var user = new Models.Users.User { IsDeleted = isDeleted };

            //Assert
            Assert.AreEqual(isDeleted, user.IsDeleted);
        }
    }
}
