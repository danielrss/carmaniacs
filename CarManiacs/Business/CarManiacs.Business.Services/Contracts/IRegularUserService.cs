using CarManiacs.Business.Models.Users;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IRegularUserService
    {
        void Create(string userId, string email, string firstName, string lastName);

        RegularUser GetById(string id);

        RegularUser GetByEmail(string email);
    }
}
