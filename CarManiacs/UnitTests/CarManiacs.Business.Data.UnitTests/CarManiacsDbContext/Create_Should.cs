using CarManiacs.Business.Data.Contracts;

using NUnit.Framework;

namespace CarManiacs.Business.Data.UnitTests.CarManiacsDbContext
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ReturnObjectOfTypeICarManiacsDbContext()
        {
            //Arrange & Act
            var dbContext = Data.CarManiacsDbContext.Create();

            //Assert
            Assert.IsInstanceOf<ICarManiacsDbContext>(dbContext);
        }
    }
}
