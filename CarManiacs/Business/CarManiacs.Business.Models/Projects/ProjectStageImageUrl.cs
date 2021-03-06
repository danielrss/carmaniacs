﻿using CarManiacs.Business.Common;

using System;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.Business.Models.Projects
{
    public class ProjectStageImageUrl
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(Constants.UrlMinLength)]
        [MaxLength(Constants.UrlMaxLength)]
        public string Url { get; set; }

        [Required]
        public Guid ProjectStageId { get; set; }

        public virtual ProjectStage ProjectStage { get; set; }
    }
}
