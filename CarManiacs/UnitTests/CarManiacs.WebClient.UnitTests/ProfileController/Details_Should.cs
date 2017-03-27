using CarManiacs.Business.Models.Users;
using CarManiacs.Business.Services.Contracts;
using CarManiacs.WebClient.Models;
using Moq;
using NUnit.Framework;
using System;
using TestStack.FluentMVCTesting;

namespace CarManiacs.WebClient.UnitTests.ProfileController
{
    [TestFixture]
    public class Details_Should
    {
        [Test]
        public void ReturnHttpNotFound_WhenUserFromRepoIsNull()
        {
            // Arrange
            var regularUserServiceMock = new Mock<IRegularUserService>();
            var profileController = new WebClient.Controllers.ProfileController(regularUserServiceMock.Object);
            RegularUser userFromService = null;
            var userId = Guid.NewGuid().ToString();
            regularUserServiceMock.Setup(m => m.GetById(userId)).Returns(userFromService);

            //Act & Assert
            profileController
                .WithCallTo(c => c.Details(userId))
                .ShouldGiveHttpStatus(404);
        }
    }
}
