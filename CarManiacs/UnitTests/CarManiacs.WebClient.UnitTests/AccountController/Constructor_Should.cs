using CarManiacs.Business.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.WebClient.UnitTests.AccountController
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateAccountController_WhenParamsAreValid()
        {
            // Arrange
            var regularUserServiceMock = new Mock<IRegularUserService>();
            var accountController = new WebClient.Controllers.AccountController(regularUserServiceMock.Object);

            //Act & Assert
            Assert.That(accountController, Is.Not.Null.And.InstanceOf<WebClient.Controllers.AccountController>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenRegularUserServiceIsNull()
        {
            //Arrange && Act & Assert
            Assert.Throws<ArgumentNullException>(() => new WebClient.Controllers.AccountController(null));
        }
    }
}
