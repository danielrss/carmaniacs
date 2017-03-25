using CarManiacs.Business.Common;
using CarManiacs.Business.Models.Projects;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManiacs.Business.Models.Users
{
    public class RegularUser
    {
        private ICollection<Project> projects;

        public RegularUser()
        {
            this.projects = new HashSet<Project>();
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
    }
}
