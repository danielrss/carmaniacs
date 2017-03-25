﻿using CarManiacs.Business.Common;

using System.ComponentModel.DataAnnotations;

namespace CarManiacs.WebClient.Models
{
    public class ProfileDetailsViewModel
    {
        public bool IsUserAllowedToEdit { get; set; }
        
        public string AvatarUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        [Display(Name = "Current car")]
        public string CurrentCar { get; set; }

        [Display(Name = "Favorite car")]
        public string FavoriteCar { get; set; }

        [Display(Name = "Has been a CarManiac for")]
        public int CarManiacForDays { get; set; }
    }

    public class ProfileEditViewModel
    {
        [Display(Name = "First name")]
        [StringLength(Constants.NameMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.NameMinLength)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [StringLength(Constants.NameMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.NameMinLength)]
        public string LastName { get; set; }

        [Range(Constants.MinAge, Constants.MaxAge)]
        public int? Age { get; set; }

        [Display(Name = "Current car")]
        [StringLength(Constants.NameMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.NameMinLength)]
        public string CurrentCar { get; set; }

        [Display(Name = "Favorite car")]
        [StringLength(Constants.NameMaxLength, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Constants.NameMinLength)]
        public string FavoriteCar { get; set; }
    }
}