using CarManiacs.Business.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.Business.Models.Projects
{
    public class ProjectStage
    {
        private ICollection<ProjectStageImageUrl> images;

        public ProjectStage()
        {
            this.images = new HashSet<ProjectStageImageUrl>();
        }

        [Key]
        public Guid Id { get; set; }
        
        [MinLength(Constants.TitleMinLength)]
        [MaxLength(Constants.TitleMaxLength)]
        public string Title { get; set; }

        [MinLength(Constants.ProjectDescriptionMinLength)]
        [MaxLength(Constants.ProjectDescriptionMaxLength)]
        public string Description { get; set; }

        public Guid ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<ProjectStageImageUrl> ImageUrls
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
            }
        }
    }
}
