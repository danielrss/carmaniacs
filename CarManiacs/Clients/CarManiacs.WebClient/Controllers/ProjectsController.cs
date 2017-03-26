using Bytes2you.Validation;
using CarManiacs.Business.DTOs;
using CarManiacs.Business.Services.Contracts;
using CarManiacs.WebClient.ActionFilters;
using CarManiacs.WebClient.Models;
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
        private IRegularUserService regularUserService;

        public ProjectsController(
            IProjectService projectService,
            IRegularUserService regularUserService)
        {
            Guard.WhenArgument(projectService, "projectService").IsNull().Throw();
            Guard.WhenArgument(regularUserService, "regularUserService").IsNull().Throw();

            this.regularUserService = regularUserService;
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
                if (project.Stages != null && project.Stages.Count > 0)
                {
                    projectStages = project.Stages.Select(s => new ProjectStageViewModel() { });
                }

                IEnumerable<CommentViewModel> projectComments = null;
                if (project.Comments != null && project.Comments.Count > 0)
                {
                    projectComments = project.Comments.Select(
                        c => new CommentViewModel()
                        {
                            UserFullName = c.UserId == null ? null : c.User.FirstName + " " + c.User.LastName,
                            UserId = c.UserId,
                            Comment = c.Content,
                            PublishDate = c.PublishDate
                        });
                }

                string starLinkClass = "fa-star-o";
                if (this.User.Identity.IsAuthenticated && this.projectService.HasUserStarred(id, this.User.Identity.GetUserId()))
                {
                    starLinkClass = "fa-star";
                }

                var viewModel = new ProjectDetailsViewModel()
                {
                    Id = project.Id,
                    Title = project.Title,
                    Description = project.Description,
                    UserFullName = project.User.FirstName + " " + project.User.LastName,
                    UserId = project.UserId,
                    Stages = projectStages,
                    StartDate = project.StartDate,
                    ImageUrl = project.ImageUrl,
                    NumberOfStars = project.Stars.Count,
                    StarLinkClass = starLinkClass,
                    Comments = projectComments,
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
        
        [HttpPost]
        [Transaction]
        public ActionResult StarOrUnstar(Guid id)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, responseText = "Not authorized." }, JsonRequestBehavior.AllowGet);
            }
            
            int numberOfStars = this.projectService.StarOrUnstar(id, this.User.Identity.GetUserId());
            return this.Content(" " + numberOfStars.ToString());
        }

        [HttpPost]
        [Transaction]
        public ActionResult Comment(Guid id, string commentContent)
        {
            Guard.WhenArgument(commentContent, "commentContent").IsNullOrEmpty().Throw();
            string userId = this.User.Identity.GetUserId();
            string userFullName = null;
            if (userId != null)
            {
                var user = this.regularUserService.GetById(userId);
                userFullName = user.FirstName + " " + user.LastName;
            }

            this.projectService.Comment(id, userId, commentContent);

            return this.PartialView("_CommentPartial", new CommentViewModel()
            {
                Comment = commentContent,
                UserFullName = userFullName,
                PublishDate = DateTime.Now,
                UserId = userId
            });
        }
    }
}