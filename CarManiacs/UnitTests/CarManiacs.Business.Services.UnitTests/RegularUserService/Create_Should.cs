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
        public void CallRegularUserRepoAdd_WhenIdIsValid()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);
            var id = Guid.NewGuid().ToString();

            //Act
            var createdUser = regularUserService.Create(id);

            //Assert
            usersRepoMock.Verify(m => m.Add(createdUser), Times.Once);
        }

        [Test]
        public void ReturnUserWithThePassedId_WhenIdIsValid()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);
            var id = Guid.NewGuid().ToString();

            //Act
            var createdUser = regularUserService.Create(id);

            //Assert
            Assert.AreEqual(id, createdUser.Id);
        }

        [Test]
        public void ThrowArgumentNullException_WhenIdIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => regularUserService.Create(null));
        }

        [Test]
        public void ThrowArgumentException_WhenIdIsEmpty()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => regularUserService.Create(string.Empty));
        }
    }
}
