using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Users;
using CarManiacs.DTOs;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.RegularUserService
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void CallRegularUserRepoUpdateOnce_WhenUserIsExistent()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var userDto = new RegularUserDto() { Id = Guid.NewGuid().ToString() };
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);
            var userFromRepo = new Mock<RegularUser>();
            usersRepoMock.Setup(m => m.GetById(userDto.Id)).Returns(userFromRepo.Object);

            //Act
            regularUserService.Update(userDto);

            //Assert
            usersRepoMock.Verify(m => m.Update(userFromRepo.Object), Times.Once);
        }

        [Test]
        public void NotCallRegularUserRepoUpdate_WhenUserIsExistent()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var userDto = new RegularUserDto() { Id = Guid.NewGuid().ToString() };
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);
            RegularUser nullUserFromRepo = null;
            usersRepoMock.Setup(m => m.GetById(userDto.Id)).Returns(nullUserFromRepo);

            //Act
            regularUserService.Update(userDto);

            //Assert
            usersRepoMock.Verify(m => m.Update(nullUserFromRepo), Times.Never);
        }

        [Test]
        public void ThrowArgumentNullException_WhenUpdatedUserIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => regularUserService.Update(null));
        }
    }
}
