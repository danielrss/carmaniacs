using CarManiacs.Business.Models.Projects;
using System;
using System.Collections.Generic;

namespace CarManiacs.Business.Services.Contracts
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAll();

        Project GetById(Guid projectId);
    }
}
