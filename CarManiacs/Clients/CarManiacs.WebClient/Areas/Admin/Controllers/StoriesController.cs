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
    public class StoriesController : BaseController
    {
        private IStoryService storyService;

        public StoriesController(IStoryService storyService)
        {
            Guard.WhenArgument(storyService, "storyService").IsNull().Throw();

            this.storyService = storyService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReadStories([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.storyService
                .GetAll()
                .Select(s => new StoryViewModel()
                {
                    Id = s.Id,
                    UserId = s.UserId,
                    Content = s.Content,
                    MainImageUrl = s.MainImageUrl,
                    IsDeleted = s.IsDeleted,
                    PublishDate = s.PublishDate,
                    Title = s.Title
                })
                .ToDataSourceResult(request);
            return Json(result);
        }

        [HttpPost]
        [Transaction]
        public ActionResult UpdateStory([DataSourceRequest]DataSourceRequest request, StoryViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.storyService.Update(new StoryDto()
                {
                    Id = model.Id,
                    Content = model.Content,
                    Title = model.Title
                });
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        [Transaction]
        public ActionResult CreateStory([DataSourceRequest]DataSourceRequest request, StoryViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.storyService.Create(new StoryDto()
                {
                    Content = model.Content,
                    Title = model.Title
                }, this.User.Identity.GetUserId());
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        [Transaction]
        public ActionResult DestroyStory([DataSourceRequest]DataSourceRequest request, StoryViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.storyService.Delete(model.Id);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}