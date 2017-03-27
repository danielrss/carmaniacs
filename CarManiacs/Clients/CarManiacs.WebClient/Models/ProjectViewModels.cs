using CarManiacs.Business.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.WebClient.Models
{
    public class ProjectDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "Builder")]
        public string UserFullName { get; set; }

        public string UserId { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "Start date")]
        public DateTime? StartDate { get; set; }

        public IEnumerable<ProjectStageViewModel> Stages { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public int NumberOfStars { get; set; }

        public string StarLinkClass { get; set; }

        public bool IsUserAllowedToEdit { get; set; }

        public bool HasUserStarred { get; set; }
    }

    public class ProjectCreateViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(Constants.TitleMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.TitleMinLength)]
        public string Title { get; set; }

        [StringLength(Constants.ProjectDescriptionMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.ProjectDescriptionMinLength)]
        public string Description { get; set; }
    }

    public class ProjectShortViewModel
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int NumberOfStars { get; set; }

        public int NumberOfComments { get; set; }
    }
}