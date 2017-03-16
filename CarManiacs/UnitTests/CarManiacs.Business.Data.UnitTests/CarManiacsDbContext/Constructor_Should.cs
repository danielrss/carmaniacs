using CarManiacs.Business.Data.Contracts;

using NUnit.Framework;

namespace CarManiacs.Business.Data.UnitTests.CarManiacsDbContext
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateObjectOfTypeICarManiacsDbContext()
        {
            //Arange && Act
            var dbContext = new Data.CarManiacsDbContext();

            //Assert
            Assert.IsInstanceOf<ICarManiacsDbContext>(dbContext);
        }
    }
}
