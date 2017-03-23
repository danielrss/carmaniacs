using CarManiacs.Business.Data.Contracts;
using CarManiacs.WebClient.ActionFilters;

namespace CarManiacs.WebClient.UnitTests.Mocks
{
    public class TransactionAttributeMock : TransactionAttribute
    {
        public IEfUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
            set
            {
                this.unitOfWork = value;
            }
        }
    }
}
