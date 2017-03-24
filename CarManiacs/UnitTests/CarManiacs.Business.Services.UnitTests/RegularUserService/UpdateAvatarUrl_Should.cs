using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Users;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.RegularUserService
{
    [TestFixture]
    public class UpdateAvatarUrl_Should
    {
        [Test]
        public void CallRegularUserRepoUpdateOnce_WhenUserIsExistent()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);
            var userFromRepo = new Mock<RegularUser>();
            string userId = Guid.NewGuid().ToString();
            usersRepoMock.Setup(m => m.GetById(userId)).Returns(userFromRepo.Object);

            //Act
            regularUserService.UpdateAvatarUrl(userId, "tootaallyyRandomAvatarUrl");

            //Assert
            usersRepoMock.Verify(m => m.Update(userFromRepo.Object), Times.Once);
        }

        [Test]
        public void NotCallRegularUserRepoUpdate_WhenUserIsNonExistent()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            string userId = Guid.NewGuid().ToString();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);
            RegularUser nullUserFromRepo = null;
            usersRepoMock.Setup(m => m.GetById(userId)).Returns(nullUserFromRepo);

            //Act
            regularUserService.UpdateAvatarUrl(userId, "tootaallyyRandomAvatarUrl2");

            //Assert
            usersRepoMock.Verify(m => m.Update(nullUserFromRepo), Times.Never);
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => regularUserService.UpdateAvatarUrl(null, "raandoomStriing"));
        }

        [Test]
        public void ThrowArgumentException_WhenUserIdIsEmpty()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => regularUserService.UpdateAvatarUrl(string.Empty, "raandoomStriing2"));
        }
    }
}
