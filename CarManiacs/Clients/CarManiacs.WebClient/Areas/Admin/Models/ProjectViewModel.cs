using CarManiacs.Business.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.WebClient.Areas.Admin.Models
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        [Required]
        [StringLength(Constants.TitleMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.TitleMinLength)]
        public string Title { get; set; }

        [StringLength(Constants.ProjectDescriptionMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.ProjectDescriptionMinLength)]
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }
        
        public DateTime StartDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}