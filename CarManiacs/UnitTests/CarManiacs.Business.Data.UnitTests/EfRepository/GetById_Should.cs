using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Locations;

using Moq;
using NUnit.Framework;

namespace CarManiacs.Business.Data.UnitTests.EfRepository
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ShouldCallDbSetFind()
        {
            //Arrange
            var dbContextMock = new Mock<ICarManiacsDbContext>();

            City[] dbSetObjects = new City[] { new City() };
            var dbSetMock = Common.GetQueryableDbSetMock<City>(dbSetObjects);
            dbContextMock.Setup(x => x.Set<City>()).Returns(dbSetMock.Object);
            var objectId = dbSetObjects[0].Id;

            var repository = new EfRepository<City>(dbContextMock.Object);

            //Act
            repository.GetById(objectId);

            //Assert
            dbSetMock.Verify(m => m.Find(objectId), Times.Once);
        }
    }
}
