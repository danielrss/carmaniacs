using Bytes2you.Validation;
using CarManiacs.Business.Data.Contracts;

namespace CarManiacs.Business.Data
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ICarManiacsDbContext context;

        public EfUnitOfWork(ICarManiacsDbContext context)
        {
            Guard.WhenArgument(context, "dbContext").IsNull().Throw();

            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
