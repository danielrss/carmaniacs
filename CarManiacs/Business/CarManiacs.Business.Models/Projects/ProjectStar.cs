using CarManiacs.Business.Models.Users;

using System;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.Business.Models.Projects
{
    public class ProjectStar
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }
        
        public string UserId { get; set; }

        public virtual RegularUser User { get; set; }
    }
}
