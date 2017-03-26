using CarManiacs.Business.Common;
using CarManiacs.Business.Data.Contracts;
using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Projects;
using CarManiacs.Business.Services.Contracts;

using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManiacs.Business.Services
{
    public class ProjectService : IProjectService
    {
        private IEfRepository<Project> projectsRepo;
        private IEfRepository<ProjectStar> projectStarsRepo;

        public ProjectService(
            IEfRepository<Project> projectsRepo, 
            IEfRepository<ProjectStar> projectStarsRepo)
        {
            Guard.WhenArgument(projectsRepo, "Project repository").IsNull().Throw();
            Guard.WhenArgument(projectStarsRepo, "ProjectStar repository").IsNull().Throw();

            this.projectsRepo = projectsRepo;
            this.projectStarsRepo = projectStarsRepo;
        }

        public Guid Create(ProjectDto newProject, string userId)
        {
            Guard.WhenArgument(newProject, "projectDto").IsNull().Throw();
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var project = new Project()
            {
                Id = Guid.NewGuid(),
                Title = newProject.Title,
                Description = newProject.Description,
                StartDate = DateTime.Now,
                UserId = userId,
                ImageUrl = Constants.DefaultProjectImageUrl
            };

            this.projectsRepo.Add(project);
            return project.Id;
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

        public int StarOrUnstar(Guid projectId, string userId)
        {
            Guard.WhenArgument(projectId, "projectId").IsEmptyGuid().Throw();
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var project = this.projectsRepo.GetById(projectId);
            if (project != null)
            {
                var projectStar = project.Stars.FirstOrDefault(s => s.UserId == userId);
                if (projectStar != null)
                {
                    project.Stars.Remove(projectStar);
                    this.projectStarsRepo.Delete(projectStar);
                    return project.Stars.Count;
                }
                else
                {
                    projectStar = new ProjectStar() { Id = Guid.NewGuid(), ProjectId = projectId, UserId = userId };
                    project.Stars.Add(projectStar);
                    return project.Stars.Count;
                }
            }

            return -1;
        }

        public bool HasUserStarred(Guid projectId, string userId)
        {
            Guard.WhenArgument(projectId, "projectId").IsEmptyGuid().Throw();
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var project = this.projectsRepo.GetById(projectId);
            if (project != null)
            {
                var projectStar = project.Stars.FirstOrDefault(s => s.UserId == userId);
                if (projectStar != null)
                {
                    return true;
                }
            }

            return false;
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

        public void Comment(Guid projectId, string userId, string comment)
        {
            Guard.WhenArgument(projectId, "projectId").IsEmptyGuid().Throw();
            Guard.WhenArgument(comment, "comment").IsNullOrEmpty().Throw();
            
            var project = this.projectsRepo.GetById(projectId);
            if (project != null)
            {
                project.Comments.Add(new ProjectComment()
                {
                    Id = Guid.NewGuid(),
                    Content = comment,
                    PublishDate = DateTime.Now,
                    ProjectId = projectId,
                    UserId = userId
                });
            }
        }
    }
}
