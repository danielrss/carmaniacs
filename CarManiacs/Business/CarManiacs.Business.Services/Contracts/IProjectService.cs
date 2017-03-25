using CarManiacs.Business.DTOs;
using CarManiacs.Business.Models.Projects;

using System;
using System.Collections.Generic;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IProjectService
    {
        void Create(ProjectDto newProject, string userId);

        void Update(ProjectDto updatedProject);

        IEnumerable<Project> GetAll();

        Project GetById(Guid projectId);
    }
}
