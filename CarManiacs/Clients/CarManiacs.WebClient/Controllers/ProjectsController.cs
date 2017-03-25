using CarManiacs.Business.Services.Contracts;
using CarManiacs.WebClient.ActionFilters;

using Bytes2you.Validation;
using System.Web.Mvc;
using CarManiacs.WebClient.Models;
using System;
using Microsoft.AspNet.Identity;

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
                var viewModel = new ProjectDetailsViewModel()
                {
                    Id = project.Id,
                    Title = project.Title,
                    IsUserAllowedToEdit = this.User.Identity.GetUserId() == project.UserId.ToString()
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
        public ActionResult Create(ProjectDetailsViewModel project)
        {
            return this.RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var project = projectService.GetById(id);
            if (project != null)
            {
                return View();
            }

            return new HttpNotFoundResult();
        }

        [Authorize]
        [HttpPost]
        [Transaction]
        public ActionResult Edit(Guid id, ProjectDetailsViewModel project)
        {
            return this.RedirectToAction("Details", new { id = id });
        }
    }
}