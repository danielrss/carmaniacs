using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Locations;
using CarManiacs.Business.Models.Projects;
using CarManiacs.Business.Models.Stories;
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

        public virtual IDbSet<Project> Projects { get; set; }

        public virtual IDbSet<ProjectStar> ProjectStars { get; set; }

        public virtual IDbSet<ProjectComment> ProjectComments { get; set; }

        public virtual IDbSet<ProjectStage> ProjectStages { get; set; }

        public virtual IDbSet<ProjectStageImageUrl> ProjectStageImageUrls { get; set; }

        public virtual IDbSet<Story> Stories { get; set; }

        public virtual IDbSet<StoryStar> StoryStars { get; set; }

        public virtual IDbSet<StoryComment> StoryComments { get; set; }

        public virtual IDbSet<StoryImageUrl> StoryImageUrls { get; set; }
    }
}
