using CarManiacs.Business.Models.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManiacs.Business.Data
{
    public class CarManiacsDbContext : IdentityDbContext<User>
    {
        public CarManiacsDbContext()
            : base("CarManiacsDb", throwIfV1Schema: false)
        {
        }

        public static CarManiacsDbContext Create()
        {
            return new CarManiacsDbContext();
        }
    }
}
