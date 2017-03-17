using CarManiacs.Business.Data.Contracts;

using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;

namespace CarManiacs.Business.Data.UnitTests.EfRepository
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            //Arrange && Act & Assert
            Assert.Throws<ArgumentNullException>(() => new EfRepository<object>(null));
        }

        [Test]
        public void SetDbContextCorrectly_WhenValidArgumentsPassed()
        {
            //Arrange
            var dbContextMock = new Mock<ICarManiacsDbContext>();

            //Act
            var repository = new EfRepository<object>(dbContextMock.Object);

            //Assert
            Assert.AreSame(dbContextMock.Object, repository.DbContext);
        }

        [Test]
        public void SetDbSetCorrectly_WhenValidArgumentsArePassed()
        {
            //Arrange
            var dbContextMock = new Mock<ICarManiacsDbContext>();
            var dbSetMock = new Mock<IDbSet<object>>();
            dbContextMock.Setup(x => x.Set<object>()).Returns(dbSetMock.Object);

            //Act
            var repository = new EfRepository<object>(dbContextMock.Object);

            //Assert
            Assert.AreSame(repository.DbSet, dbSetMock.Object);
        }

        [Test]
        public void CreateObjectOfTypeIEfRepository_WhenValidArgumentsPassed()
        {
            // Arrange
            var dbContextMock = new Mock<ICarManiacsDbContext>();

            // Act
            var repository = new EfRepository<object>(dbContextMock.Object);

            // Assert
            Assert.IsInstanceOf<IEfRepository<object>>(repository);
        }
    }
}
