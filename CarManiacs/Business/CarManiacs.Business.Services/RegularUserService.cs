using Bytes2you.Validation;

using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Users;
using CarManiacs.Business.Services.Contracts;

namespace CarManiacs.Business.Services
{
    public class RegularUserService : IRegularUserService
    {
        private IEfRepository<RegularUser> usersRepo;

        public RegularUserService(IEfRepository<RegularUser> usersRepo)
        {
            Guard.WhenArgument(usersRepo, "RegularUser repository").IsNull().Throw();

            this.usersRepo = usersRepo;
        }

        public void Create(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();
            
            this.usersRepo.Add(new RegularUser()
            {
                Id = userId
            });
        }

        public RegularUser GetUserById(string id)
        {
            return this.usersRepo.GetById(id);
        }
    }
}
