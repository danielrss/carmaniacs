using CarManiacs.Business.Common;
using CarManiacs.Business.Models.Users;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.Business.Models.Stories
{
    public class Story
    {
        private ICollection<StoryImageUrl> images;
        private ICollection<StoryStar> stars;
        private ICollection<StoryComment> comments;

        public Story()
        {
            this.images = new HashSet<StoryImageUrl>();
            this.stars = new HashSet<StoryStar>();
            this.comments = new HashSet<StoryComment>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(Constants.TitleMinLength)]
        [MaxLength(Constants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(Constants.StoryContentMinLength)]
        [MaxLength(Constants.StoryContentMaxLength)]
        public string Content { get; set; }

        [Required]
        [MinLength(Constants.UrlMinLength)]
        [MaxLength(Constants.UrlMaxLength)]
        public string MainImageUrl { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual RegularUser User { get; set; }

        public virtual ICollection<StoryImageUrl> ImageUrls
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

        public virtual ICollection<StoryStar> Stars
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

        public virtual ICollection<StoryComment> Comments
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
