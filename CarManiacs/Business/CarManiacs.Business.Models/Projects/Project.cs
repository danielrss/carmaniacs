using CarManiacs.Business.Common;

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
            this.Id = Guid.NewGuid();
            this.stages = new HashSet<ProjectStage>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(Constants.TitleMinLength)]
        [MaxLength(Constants.TitleMaxLength)]
        public string Title { get; set; }

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
