using CarManiacs.Business.Common;
using CarManiacs.Business.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.Business.Models.Projects
{
    public class ProjectComment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(Constants.MinCommentLength)]
        [MaxLength(Constants.MaxCommentLength)]
        public string Content { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string UserId { get; set; }

        public virtual RegularUser User { get; set; }
    }
}
