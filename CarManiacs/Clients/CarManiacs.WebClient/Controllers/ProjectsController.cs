using CarManiacs.Business.DTOs;
using CarManiacs.Business.Services.Contracts;
using CarManiacs.WebClient.ActionFilters;
using CarManiacs.WebClient.Models;

using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarManiacs.WebClient.Controllers
{
    public class ProjectsController : BaseController
    {
        private IProjectService projectService;

        public ProjectsController(IProjectService projectService)
        {
            Guard.WhenArgument(projectService, "projectService").IsNull().Throw();

            this.projectService = projectService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            var project = projectService.GetById(id);
            
            if (project != null)
            {
                IEnumerable<ProjectStageViewModel> projectStages = null;
                if (project.Stages != null)
                {
                    projectStages = project.Stages.Select(s => new ProjectStageViewModel() { });
                }

                var viewModel = new ProjectDetailsViewModel()
                {
                    Id = project.Id,
                    Title = project.Title,
                    Description = project.Description,
                    UserFullName = project.User.FirstName + " " + project.User.LastName,
                    UserId = project.UserId,
                    Stages = projectStages,
                    ImageUrl = project.ImageUrl,
                    IsUserAllowedToEdit = this.User.Identity.GetUserId() == project.UserId
                };
                return View(viewModel);
            }

            return new HttpNotFoundResult();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Transaction]
        public ActionResult Create(ProjectCreateViewModel project)
        {
            if (!this.ModelState.IsValid)
            {
                return View(project);
            }

            var projectDto = new ProjectDto()
            {
                Title = project.Title,
                Description = project.Description
            };
            var projectId = this.projectService.Create(projectDto, this.User.Identity.GetUserId());

            return this.RedirectToAction("Details", new { id = projectId });
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var project = projectService.GetById(id);

            if (project != null && project.UserId == this.User.Identity.GetUserId())
            {
                var viewModel = new ProjectCreateViewModel()
                {
                    Id = project.Id,
                    Title = project.Title,
                    Description = project.Description
                };
                return View(viewModel);
            }

            return new HttpNotFoundResult();
        }

        [Authorize]
        [HttpPost]
        [Transaction]
        public ActionResult Edit(ProjectCreateViewModel project)
        {
            if (!this.ModelState.IsValid)
            {
                return View(project);
            }

            var projectDto = new ProjectDto()
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description
            };
            this.projectService.Update(projectDto);
            
            return this.RedirectToAction("Details", new { id = project.Id });
        }
    }
}