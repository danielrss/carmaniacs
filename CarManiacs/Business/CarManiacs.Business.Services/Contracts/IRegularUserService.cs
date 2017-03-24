using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Users;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IRegularUserService
    {
        void Create(string userId, string email, string firstName, string lastName);

        RegularUser GetById(string userId);

        RegularUser GetByEmail(string userEmail);

        void Update(RegularUserDto updatedUser);

        void UpdateAvatarUrl(string userId, string avatarUrl);
    }
}
