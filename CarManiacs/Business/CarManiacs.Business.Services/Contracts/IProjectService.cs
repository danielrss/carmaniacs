using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Projects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IProjectService
    {
        Guid Create(ProjectDto newProject, string userId);

        void Update(ProjectDto updatedProject);

        void UpdateImageUrl(Guid projectId, string imageUrl);

        void Delete(Guid projectId);

        int StarOrUnstar(Guid projectId, string userId);
        
        bool HasUserStarred(Guid projectId, string userId);
        
        void Comment(Guid projectId, string userId, string comment);

        IEnumerable<Project> Get(int page, int numberOfProjects);

        IEnumerable<Project> Search(string searchTerm);

        IQueryable<Project> GetAll();

        Project GetById(Guid projectId);
    }
}
