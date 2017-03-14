using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CarManiacs.Business.Data.Contracts
{
    public interface ICarManiacsDbContext : IDisposable
    {
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
