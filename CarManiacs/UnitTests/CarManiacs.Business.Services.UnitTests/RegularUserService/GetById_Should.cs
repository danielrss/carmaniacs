using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Users;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.RegularUserService
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void CallRegularUserRepoFind_WhenIdIsValid()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);
            var id = Guid.NewGuid().ToString();

            //Act
            regularUserService.GetById(id);

            //Assert
            usersRepoMock.Verify(m => m.GetById(id), Times.Once);
        }

        [Test]
        public void ThrowArgumentNullException_WhenIdIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => regularUserService.GetById(null));
        }

        [Test]
        public void ThrowArgumentException_WhenIdIsEmpty()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => regularUserService.GetById(string.Empty));
        }
    }
}
