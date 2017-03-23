using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Users;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.RegularUserService
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void CallRegularUserRepoAddOnce_WhenIdIsValid()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);
            var id = Guid.NewGuid().ToString();

            //Act
            regularUserService.Create(id, "randomNotNullOrEmptyStringEmail", null, null);

            //Assert
            usersRepoMock.Verify(m => m.Add(It.IsAny<RegularUser>()), Times.Once);
        }

        [Test]
        public void ThrowArgumentNullException_WhenIdIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => regularUserService.Create(null, "randomNotNullOrEmptyStringEmail", null, null));
        }

        [Test]
        public void ThrowArgumentException_WhenIdIsEmpty()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => regularUserService.Create(string.Empty, "randomNotNullOrEmptyStringEmail", null, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenEmailIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => regularUserService.Create(Guid.NewGuid().ToString(), null, null, null));
        }

        [Test]
        public void ThrowArgumentException_WhenEmailIsEmpty()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => regularUserService.Create(Guid.NewGuid().ToString(), string.Empty, null, null));
        }
    }
}
