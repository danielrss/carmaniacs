using CarManiacs.Business.Data.Contracts;

using Moq;
using NUnit.Framework;
using System.Linq;

namespace CarManiacs.Business.Data.UnitTests.EfRepository
{
    [TestFixture]
    public class All_Should
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void ShouldReturnAllObjectsFromDbSet(int objectsInDbSet)
        {
            //Arrange
            var dbContextMock = new Mock<ICarManiacsDbContext>();

            object[] dbSetObjects = new object[objectsInDbSet];
            for (int i = 0; i < objectsInDbSet; i++)
            {
                dbSetObjects[i] = new object();
            }

            dbContextMock.Setup(x => x.Set<object>()).Returns(Common.GetQueryableDbSetMock<object>(dbSetObjects).Object);
            var repository = new EfRepository<object>(dbContextMock.Object);

            //Act
            var repoAll = repository.All();

            //Assert
            Assert.AreEqual(objectsInDbSet, repoAll.Count());
        }
    }
}
