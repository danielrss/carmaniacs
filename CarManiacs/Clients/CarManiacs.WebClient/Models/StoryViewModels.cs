using CarManiacs.Business.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.WebClient.Models
{
    public class StoryDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [Display(Name = "Author")]
        public string UserFullName { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Published on")]
        public DateTime PublishDate { get; set; }

        public string MainImageUrl { get; set; }

        public IEnumerable<string> ImageUrls { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public int NumberOfStars { get; set; }

        public string StarLinkClass { get; set; }

        public bool IsUserAllowedToEdit { get; set; }

        public bool HasUserStarred { get; set; }
    }

    public class StoryCreateViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(Constants.TitleMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(Constants.StoryContentMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.StoryContentMinLength)]
        public string Content { get; set; }
    }
}