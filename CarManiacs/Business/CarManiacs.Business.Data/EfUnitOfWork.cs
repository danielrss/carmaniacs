using Bytes2you.Validation;

using CarManiacs.Business.Data.Contracts;

namespace CarManiacs.Business.Data
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        protected readonly ICarManiacsDbContext dbContext;

        public EfUnitOfWork(ICarManiacsDbContext context)
        {
            Guard.WhenArgument(context, "dbContext").IsNull().Throw();

            this.dbContext = context;
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
