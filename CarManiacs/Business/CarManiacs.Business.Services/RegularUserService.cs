using Bytes2you.Validation;

using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Users;
using CarManiacs.Business.Services.Contracts;

namespace CarManiacs.Business.Services
{
    public class RegularUserService : IRegularUserService
    {
        private IEfRepository<RegularUser> usersRepo;

        public RegularUserService(IEfRepository<RegularUser> regularUsersRepo)
        {
            Guard.WhenArgument(regularUsersRepo, "RegularUser repository").IsNull().Throw();

            this.usersRepo = regularUsersRepo;
        }

        public RegularUser Create(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var user = new RegularUser()
            {
                Id = userId
            };
            this.usersRepo.Add(user);

            return user;
        }

        public RegularUser GetById(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            return this.usersRepo.GetById(userId);
        }
    }
}
