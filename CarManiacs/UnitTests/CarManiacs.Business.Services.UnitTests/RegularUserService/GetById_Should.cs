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

        [TestCase(null)]
        [TestCase("")]
        public void ReturnNull_WhenIdIsNullOrEmpty(string testId)
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Act && Assert
            Assert.IsNull(regularUserService.GetById(testId));
        }
    }
}
