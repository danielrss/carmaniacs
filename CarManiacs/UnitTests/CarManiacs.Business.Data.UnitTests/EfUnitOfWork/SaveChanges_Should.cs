using CarManiacs.Business.Data.Contracts;

using Moq;
using NUnit.Framework;

namespace CarManiacs.Business.Data.UnitTests.EfUnitOfWork
{
    [TestFixture]
    public class SaveChanges_Should
    {
        [Test]
        public void CallDbContexSaveChangesOnce()
        {
            //Arrange
            var dbContextMock = new Mock<ICarManiacsDbContext>();
            var unitOfWork = new Data.EfUnitOfWork(dbContextMock.Object);

            //Act
            unitOfWork.SaveChanges();

            //Assert
            dbContextMock.Verify(mock => mock.SaveChanges(), Times.Once());
        }
    }
}
