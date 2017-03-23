using CarManiacs.Business.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManiacs.Business.Models.Locations
{
    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
            this.cities = new HashSet<City>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }
            set
            {
                this.cities = value;
            }
        }
    }
}
