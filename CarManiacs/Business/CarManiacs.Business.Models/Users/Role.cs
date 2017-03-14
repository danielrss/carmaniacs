using Microsoft.AspNet.Identity.EntityFramework;

namespace CarManiacs.Business.Models.Users
{
    public class Role : IdentityRole
    {
        public Role() : base() { }

        public Role(string name) : base(name) { }

        public string Description { get; set; }
    }
}
