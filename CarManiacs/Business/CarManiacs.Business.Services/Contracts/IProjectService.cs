using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Projects;

using System;
using System.Collections.Generic;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IProjectService
    {
        Guid Create(ProjectDto newProject, string userId);

        void Update(ProjectDto updatedProject);

        void UpdateImageUrl(Guid projectId, string imageUrl);

        int StarOrUnstar(Guid projectId, string userId);
        
        bool HasUserStarred(Guid projectId, string userId);
        
        void Comment(Guid projectId, string userId, string comment);

        IEnumerable<Project> Get(int page, int numberOfProjects);

        IEnumerable<Project> Search(string searchTerm);

        Project GetById(Guid projectId);
    }
}
