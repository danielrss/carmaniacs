using Bytes2you.Validation;
using CarManiacs.Business.DTOs;
using CarManiacs.Business.Services.Contracts;
using CarManiacs.WebClient.ActionFilters;
using CarManiacs.WebClient.Areas.Admin.Models;
using CarManiacs.WebClient.Controllers;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CarManiacs.WebClient.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize(Roles = "Admin")]
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

        [HttpPost]
        public ActionResult ReadProjects([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.projectService
                .GetAll()
                .Select(p => new ProjectViewModel()
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    IsDeleted = p.IsDeleted,
                    StartDate = p.StartDate,
                    Title = p.Title
                })
                .ToDataSourceResult(request);
            return Json(result);
        }

        [HttpPost]
        [Transaction]
        public ActionResult UpdateProject([DataSourceRequest]DataSourceRequest request, ProjectViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.projectService.Update(new ProjectDto()
                {
                    Id = model.Id,
                    Description = model.Description,
                    Title = model.Title
                });
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        [Transaction]
        public ActionResult CreateProject([DataSourceRequest]DataSourceRequest request, ProjectViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.projectService.Create(new ProjectDto()
                {
                    Description = model.Description,
                    Title = model.Title
                }, this.User.Identity.GetUserId());
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        [Transaction]
        public ActionResult DestroyProject([DataSourceRequest]DataSourceRequest request, ProjectViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.projectService.Delete(model.Id);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}