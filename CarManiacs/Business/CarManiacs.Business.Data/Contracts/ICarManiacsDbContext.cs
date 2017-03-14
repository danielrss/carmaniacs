using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CarManiacs.Business.Data.Contracts
{
    public interface ICarManiacsDbContext : IDisposable
    {
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void SaveChanges();
    }
}
