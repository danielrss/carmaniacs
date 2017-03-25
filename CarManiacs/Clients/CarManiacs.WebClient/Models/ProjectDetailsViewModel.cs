using System;

namespace CarManiacs.WebClient.Models
{
    public class ProjectDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool IsUserAllowedToEdit { get; set; }
    }
}