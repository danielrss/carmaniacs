using CarManiacs.Business.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.WebClient.Areas.Admin.Models
{
    public class StoryViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(Constants.TitleMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(Constants.StoryContentMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.StoryContentMinLength)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public string UserId { get; set; }
        
        public DateTime PublishDate { get; set; }

        public string MainImageUrl { get; set; }
    }
}