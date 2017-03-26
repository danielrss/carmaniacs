using CarManiacs.Business.Common;
using CarManiacs.Business.Models.Users;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.Business.Models.Projects
{
    public class Project
    {
        private ICollection<ProjectStage> stages;

        public Project()
        {
            this.stages = new HashSet<ProjectStage>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(Constants.TitleMinLength)]
        [MaxLength(Constants.TitleMaxLength)]
        public string Title { get; set; }
        
        [MinLength(Constants.ProjectDescriptionMinLength)]
        [MaxLength(Constants.ProjectDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MinLength(Constants.UrlMinLength)]
        [MaxLength(Constants.UrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual RegularUser User { get; set; }

        public virtual ICollection<ProjectStage> Stages
        {
            get
            {
                return this.stages;
            }
            set
            {
                this.stages = value;
            }
        }
    }
}
