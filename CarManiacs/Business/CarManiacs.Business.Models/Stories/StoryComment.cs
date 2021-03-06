﻿using CarManiacs.Business.Common;
using CarManiacs.Business.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.Business.Models.Stories
{
    public class StoryComment
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
        public Guid StoryId { get; set; }

        public virtual Story Story { get; set; }

        public string UserId { get; set; }

        public virtual RegularUser User { get; set; }
    }
}
