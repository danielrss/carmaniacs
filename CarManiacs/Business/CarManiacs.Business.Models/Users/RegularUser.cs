using CarManiacs.Business.Models.Projects;

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
