using CarManiacs.Business.Data.Contracts;

using Bytes2you.Validation;
using System.Data.Entity;
using System.Linq;

namespace CarManiacs.Business.Data
{
    public class EfRepository<T> : IEfRepository<T>
        where T : class
    {
        private readonly ICarManiacsDbContext context;
        private readonly IDbSet<T> dbSet;

        public EfRepository(ICarManiacsDbContext context)
        {
            Guard.WhenArgument(context, "dbContext").IsNull().Throw();

            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public ICarManiacsDbContext DbContext
        {
            get
            {
                return this.context;
            }
        }

        public IDbSet<T> DbSet
        {
            get
            {
                return this.dbSet;
            }
        }

        public virtual IQueryable<T> All()
        {
            return this.dbSet;
        }

        public virtual T GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.dbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.dbSet.Attach(entity);
                this.dbSet.Remove(entity);
            }
        }

        public virtual void Delete(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }
    }
}
