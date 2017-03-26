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

        public ActionResult Details(Guid id)
        {
            var story = storyService.GetById(id);
            IEnumerable<string> imageUrls = null;
            if (story.ImageUrls != null && story.ImageUrls.Count > 0)
            {
                imageUrls = story.ImageUrls.Select(i => i.Url);
            }

            string starLinkClass = this.storyService.HasUserStarred(id, this.User.Identity.GetUserId()) ?
                "fa-star" : "fa-star-o";
            if (story != null)
            {
                var viewModel = new StoryDetailsViewModel()
                {
                    Id = story.Id,
                    Title = story.Title,
                    Content = story.Content,
                    UserFullName = story.User.FirstName + " " + story.User.LastName,
                    UserId = story.UserId,
                    MainImageUrl = story.MainImageUrl,
                    ImageUrls = imageUrls,
                    NumberOfStars = story.Stars.Count,
                    StarLinkClass = starLinkClass,
                    IsUserAllowedToEdit = this.User.Identity.GetUserId() == story.UserId
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
        public ActionResult Create(StoryCreateViewModel story)
        {
            if (!this.ModelState.IsValid)
            {
                return View(story);
            }

            var storyDto = new StoryDto()
            {
                Title = story.Title,
                Content = story.Content
            };
            var storyId = this.storyService.Create(storyDto, this.User.Identity.GetUserId());

            return this.RedirectToAction("Details", new { id = storyId });
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var story = storyService.GetById(id);

            if (story != null && story.UserId == this.User.Identity.GetUserId())
            {
                var viewModel = new StoryCreateViewModel()
                {
                    Id = story.Id,
                    Title = story.Title,
                    Content = story.Content
                };
                return View(viewModel);
            }

            return new HttpNotFoundResult();
        }

        [Authorize]
        [HttpPost]
        [Transaction]
        public ActionResult Edit(StoryCreateViewModel story)
        {
            if (!this.ModelState.IsValid)
            {
                return View(story);
            }

            var storyDto = new StoryDto()
            {
                Id = story.Id,
                Title = story.Title,
                Content = story.Content
            };
            this.storyService.Update(storyDto);

            return this.RedirectToAction("Details", new { id = story.Id });
        }

        [HttpPost]
        [Transaction]
        public ActionResult Star(Guid id)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, responseText = "Not authorized." }, JsonRequestBehavior.AllowGet);
            }

            int numberOfStars = this.storyService.Star(id, this.User.Identity.GetUserId());
            return this.Content(" " + numberOfStars.ToString());
        }
    }
}