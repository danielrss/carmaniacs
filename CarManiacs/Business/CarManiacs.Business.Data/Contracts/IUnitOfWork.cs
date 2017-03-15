namespace CarManiacs.Business.Data.Contracts
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
