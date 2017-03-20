using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Users;
using CarManiacs.Business.Services.Contracts;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Services.UnitTests.RegularUserService
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateObjectOfTypeIRegularUserService_WhenParamsAreValid()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();

            //Act
            var regularUserService = new Services.RegularUserService(usersRepoMock.Object);

            //Assert
            Assert.IsInstanceOf<IRegularUserService>(regularUserService);
        }

        [Test]
        public void ThrowArgumentNullException_WhenRegularUserRepositoryIsNull()
        {
            //Arrange && Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Services.RegularUserService(null));
        }
    }
}
