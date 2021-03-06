﻿using CarManiacs.Business.Common;

using System;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.Business.Models.Stories
{
    public class StoryImageUrl
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(Constants.UrlMinLength)]
        [MaxLength(Constants.UrlMaxLength)]
        public string Url { get; set; }

        [Required]
        public Guid StoryId { get; set; }

        public virtual Story Story { get; set; }
    }
}
