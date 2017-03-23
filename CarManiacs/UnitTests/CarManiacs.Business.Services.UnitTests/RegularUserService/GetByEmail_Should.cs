using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Users;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.RegularUserService
{
    [TestFixture]
    public class GetByEmail_Should
    {
        [Test]
        public void CallRegularUserRepoFind_WhenEmailIsValid()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);
            var email = Guid.NewGuid().ToString();

            //Act
            regularUserService.GetByEmail(email);

            //Assert
            usersRepoMock.Verify(m => m.All, Times.Once);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ReturnNull_WhenEmailIsNullOrEmpty(string testEmail)
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.IsNull(regularUserService.GetByEmail(testEmail));
        }
    }
}
