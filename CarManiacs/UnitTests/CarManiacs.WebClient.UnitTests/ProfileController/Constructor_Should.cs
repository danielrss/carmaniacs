using CarManiacs.Business.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.WebClient.UnitTests.ProfileController
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateProfileController_WhenParamsAreValid()
        {
            // Arrange
            var regularUserServiceMock = new Mock<IRegularUserService>();
            var profileController = new WebClient.Controllers.ProfileController(regularUserServiceMock.Object);

            //Act & Assert
            Assert.That(profileController, Is.Not.Null.And.InstanceOf<WebClient.Controllers.ProfileController>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenRegularUserServiceIsNull()
        {
            //Arrange && Act & Assert
            Assert.Throws<ArgumentNullException>(() => new WebClient.Controllers.ProfileController(null));
        }
    }
}
