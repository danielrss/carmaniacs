using CarManiacs.Business.Models.Users;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IRegularUserService
    {
        RegularUser Create(string userId);

        RegularUser GetById(string id);
    }
}
