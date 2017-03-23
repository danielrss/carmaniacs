using CarManiacs.Business.Common;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManiacs.Business.Models.Locations
{
    public class City
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(Constants.NameMinLength)]
        [MaxLength(Constants.NameMaxLength)]
        public string Name { get; set; }

        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
