using Bytes2you.Validation;
using CarManiacs.Business.Common;
using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Users;
using CarManiacs.Business.Services.Contracts;
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
                AvatarUrl = Constants.DefaultAvatarUrl,
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
        
        public void Update(RegularUserDto updatedUser)
        {
            Guard.WhenArgument(updatedUser, "user").IsNull().Throw();

            var user = this.usersRepo.GetById(updatedUser.Id);
            if (user != null)
            {
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Age = updatedUser.Age;
                user.CurrentCar = updatedUser.CurrentCar;
                user.FavoriteCar = updatedUser.FavoriteCar;

                this.usersRepo.Update(user);
            }
        }

        public void UpdateAvatarUrl(string userId, string avatarUrl)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var user = this.usersRepo.GetById(userId);
            if (user != null)
            {
                user.AvatarUrl = avatarUrl;
                this.usersRepo.Update(user);
            }
        }
    }
}
