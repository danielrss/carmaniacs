﻿using CarManiacs.Business.Common;
using CarManiacs.Business.Models.Users;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.Business.Models.Projects
{
    public class Project
    {
        private ICollection<ProjectStage> stages;
        private ICollection<ProjectStar> stars;
        private ICollection<ProjectComment> comments;

        public Project()
        {
            this.stages = new HashSet<ProjectStage>();
            this.stars = new HashSet<ProjectStar>();
            this.comments = new HashSet<ProjectComment>();
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
        public DateTime StartDate { get; set; }

        public bool IsDeleted { get; set; }

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

        public virtual ICollection<ProjectStar> Stars
        {
            get
            {
                return this.stars;
            }
            set
            {
                this.stars = value;
            }
        }

        public virtual ICollection<ProjectComment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}
