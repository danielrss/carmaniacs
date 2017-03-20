using CarManiacs.Business.Common;

using System;
using System.ComponentModel.DataAnnotations;

namespace CarManiacs.Business.Models.Projects
{
    public class ProjectStageImageUrl
    {
        public ProjectStageImageUrl()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        
        [MaxLength(Constants.UrlMaxLength)]
        public string Url { get; set; }

        public Guid ProjectStageId { get; set; }

        public virtual ProjectStage ProjectStage { get; set; }
    }
}
