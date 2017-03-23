using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Users;
using CarManiacs.Business.Services.Contracts;

using Bytes2you.Validation;
using System;
using System.Linq;

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

        public void Create(string userId, string email, string firstName, string lastName)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();
            Guard.WhenArgument(email, "email").IsNullOrEmpty().Throw();

            var user = new RegularUser()
            {
                Id = userId,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                RegisterDate = DateTime.Now
            };
            this.usersRepo.Add(user);
        }

        public RegularUser GetById(string userId)
        {
            return string.IsNullOrEmpty(userId) ? null : this.usersRepo.GetById(userId);
        }

        public RegularUser GetByEmail(string email)
        {
            return string.IsNullOrEmpty(email) ? null : this.usersRepo.All.FirstOrDefault(u => u.Email == email);
        }
    }
}
