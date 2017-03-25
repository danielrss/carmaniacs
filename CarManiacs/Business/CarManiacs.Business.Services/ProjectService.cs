using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.Models.Projects;
using CarManiacs.Business.Services.Contracts;

using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CarManiacs.Business.Services
{
    public class ProjectService : IProjectService
    {
        private IEfRepository<Project> projectsRepo;

        public ProjectService(IEfRepository<Project> projectsRepo)
        {
            Guard.WhenArgument(projectsRepo, "Project repository").IsNull().Throw();

            this.projectsRepo = projectsRepo;
        }

        public IEnumerable<Project> GetAll()
        {
            return projectsRepo.All.ToList();
        }

        public Project GetById(Guid projectId)
        {
            return this.projectsRepo.GetById(projectId);
        }
    }
}
