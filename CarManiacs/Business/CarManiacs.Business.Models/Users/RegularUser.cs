using CarManiacs.Business.Common;
using CarManiacs.Business.Models.Projects;
using CarManiacs.Business.Models.Stories;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManiacs.Business.Models.Users
{
    public class RegularUser
    {
        private ICollection<Project> projects;
        private ICollection<Story> stories;
        private ICollection<ProjectStar> projectStars;
        private ICollection<StoryStar> storyStars;

        public RegularUser()
        {
            this.projects = new HashSet<Project>();
            this.stories = new HashSet<Story>();
            this.projectStars = new HashSet<ProjectStar>();
            this.storyStars = new HashSet<StoryStar>();
        }

        [Key, ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string LastName { get; set; }
        
        [Range(Constants.MinAge, Constants.MaxAge)]
        public int? Age { get; set; }
        
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string CurrentCar { get; set; }
        
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string FavoriteCar { get; set; }

        [Required]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string Email { get; set; }
        
        [Required]
        [MinLength(Constants.UrlMinLength)]
        [MaxLength(Constants.UrlMaxLength)]
        public string AvatarUrl { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<Project> Projects
        {
            get
            {
                return this.projects;
            }
            set
            {
                this.projects = value;
            }
        }

        public virtual ICollection<Story> Stories
        {
            get
            {
                return this.stories;
            }
            set
            {
                this.stories = value;
            }
        }

        public virtual ICollection<ProjectStar> ProjectStars
        {
            get
            {
                return this.projectStars;
            }
            set
            {
                this.projectStars = value;
            }
        }

        public virtual ICollection<StoryStar> StoryStars
        {
            get
            {
                return this.storyStars;
            }
            set
            {
                this.storyStars = value;
            }
        }
    }
}
