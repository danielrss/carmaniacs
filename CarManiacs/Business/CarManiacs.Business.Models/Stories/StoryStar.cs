using CarManiacs.Business.Models.Users;

using System;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.Business.Models.Stories
{
    public class StoryStar
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid StoryId { get; set; }

        public virtual Story Story { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual RegularUser User { get; set; }
    }
}
