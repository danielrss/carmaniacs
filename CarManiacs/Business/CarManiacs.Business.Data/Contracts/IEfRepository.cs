using System.Linq;

namespace CarManiacs.Business.Data.Contracts
{
    public interface IEfRepository<T> where T : class
    {

        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);
    }
}
