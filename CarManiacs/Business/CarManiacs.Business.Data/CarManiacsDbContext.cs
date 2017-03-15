using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Locations;
using CarManiacs.Business.Models.Users;

using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CarManiacs.Business.Data
{
    public class CarManiacsDbContext : IdentityDbContext<User>, ICarManiacsDbContext
    {
        public CarManiacsDbContext()
            : base("CarManiacsDb", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarManiacsDbContext>());
        }

        public static CarManiacsDbContext Create()
        {
            return new CarManiacsDbContext();
        }

        IDbSet<T> ICarManiacsDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        int ICarManiacsDbContext.SaveChanges()
        {
            return base.SaveChanges();
        }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<RegularUser> RegularUsers { get; set; }

        public virtual IDbSet<Admin> Admins { get; set; }
    }
}
