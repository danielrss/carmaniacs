﻿using CarManiacs.Business.Data;
using CarManiacs.Business.Models.Users;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;

namespace CarManiacs.Business.Identity
{
    public class ApplicationRoleManager : RoleManager<Role>
    {
        public ApplicationRoleManager(IRoleStore<Role, string> store)
            : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, Microsoft.Owin.IOwinContext context)
        {
            var roleManager = new ApplicationRoleManager(new RoleStore<Role>(context.Get<CarManiacsDbContext>()));

            string userRole = "User";
            string adminRole = "Admin";

            if (context != null && roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new Role(userRole));
                roleManager.Create(new Role(adminRole));
            }

            return roleManager;
        }
    }
}
