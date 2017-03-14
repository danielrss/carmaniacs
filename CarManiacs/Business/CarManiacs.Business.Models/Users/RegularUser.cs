using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManiacs.Business.Models.Users
{
    public class RegularUser
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public string Email { get; set; }

        public string AvatarUrl { get; set; }

        public virtual User User { get; set; }

        public bool IsDeleted { get; set; }
    }
}
