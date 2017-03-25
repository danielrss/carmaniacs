using Bytes2you.Validation;
using CarManiacs.Business.Common;
using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Projects;
using CarManiacs.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Create(ProjectDto newProject, string userId)
        {
            Guard.WhenArgument(newProject, "projectDto").IsNull().Throw();
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var project = new Project()
            {
                Id = Guid.NewGuid(),
                Title = newProject.Title,
                Description = newProject.Description,
                UserId = userId,
                ImageUrl = Constants.DefaultProjectImageUrl
            };

            this.projectsRepo.Add(project);
        }

        public void Update(ProjectDto updatedProject)
        {
            Guard.WhenArgument(updatedProject, "projectDto").IsNull().Throw();

            var project = this.projectsRepo.GetById(updatedProject.Id);
            if (project != null)
            {
                project.Title = updatedProject.Title;
                project.Description = updatedProject.Description;

                this.projectsRepo.Update(project);
            }
        }

        public void UpdateImageUrl(Guid projectId, string imageUrl)
        {
            Guard.WhenArgument(projectId, "projectId").IsEmptyGuid().Throw();

            var project = this.projectsRepo.GetById(projectId);
            if (project != null)
            {
                project.ImageUrl = imageUrl;
                this.projectsRepo.Update(project);
            }
        }

        public IEnumerable<Project> GetAll()
        {
            return projectsRepo.All.ToList();
        }

        public Project GetById(Guid projectId)
        {
            Guard.WhenArgument(projectId, "projectId").IsEmptyGuid().Throw();

            return this.projectsRepo.GetById(projectId);
        }
    }
}
