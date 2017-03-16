using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Data.UnitTests.Mocks;

using Moq;
using NUnit.Framework;
using System;

namespace CarManiacs.Business.Data.UnitTests.EfUnitOfWork
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextParameterIsNull()
        {
            //Arrange && Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Data.EfUnitOfWork(null));
        }

        [Test]
        public void SetDbContextCorrectly_WhenParametersAreValid()
        {
            //Arrange
            var dbContextMock = new Mock<ICarManiacsDbContext>();

            //Act
            var uow = new EfUnitOfWorkMock(dbContextMock.Object);

            //Assert
            Assert.AreSame(dbContextMock.Object, uow.DbContext);
        }

        [Test]
        public void CreateObjectOfTypeIUnitOfWork_WhenParametersAreValid()
        {
            //Arrange
            var dbContextMock = new Mock<ICarManiacsDbContext>();

            //Act
            var uow = new Data.EfUnitOfWork(dbContextMock.Object);
            
            //Assert
            Assert.IsInstanceOf<IUnitOfWork>(uow);
        }
    }
}
