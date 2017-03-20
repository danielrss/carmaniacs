using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManiacs.Business.Models.Users
{
    public class Admin
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }
    }
}
