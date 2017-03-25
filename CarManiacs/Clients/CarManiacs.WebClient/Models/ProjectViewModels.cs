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

        public IEnumerable<ProjectStageViewModel> Stages { get; set; }

        public bool IsUserAllowedToEdit { get; set; }
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
}