using CarManiacs.Business.Data.Contracts;

namespace CarManiacs.Business.Data.UnitTests.Mocks
{
    public class EfUnitOfWorkMock : Data.EfUnitOfWork
    {
        public EfUnitOfWorkMock(ICarManiacsDbContext context) : base(context)
        {
        }

        public ICarManiacsDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }
    }
}
