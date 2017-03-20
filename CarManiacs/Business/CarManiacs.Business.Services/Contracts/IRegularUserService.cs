﻿using CarManiacs.Business.Models.Users;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IRegularUserService
    {
        void Create(string userId);

        RegularUser GetUserById(string id);
    }
}
