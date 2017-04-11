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
    public class StoriesController : BaseController
    {
        private IStoryService storyService;
        private IRegularUserService regularUserService;

        public StoriesController(
            IStoryService storyService,
            IRegularUserService regularUserService)
        {
            Guard.WhenArgument(storyService, "storyService").IsNull().Throw();
            Guard.WhenArgument(regularUserService, "regularUserService").IsNull().Throw();

            this.storyService = storyService;
            this.regularUserService = regularUserService;
        }

        public ActionResult Index()
        {
            var stories = this.storyService.Get(0, Business.Common.Constants.InitialEntitiesPerPage).Select(
                   s => new StoryShortViewModel()
                   {
                       Id = s.Id,
                       Title = s.Title,
                       ImageUrl = s.MainImageUrl,
                       NumberOfStars = s.Stars.Count,
                       NumberOfComments = s.Comments.Count
                   });

            return View(stories);
        }

        public ActionResult LoadPage(int id)
        {
            var stories = this.storyService.Get(id, Business.Common.Constants.InitialEntitiesPerPage).Select(
                s => new StoryShortViewModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImageUrl = s.MainImageUrl,
                    NumberOfStars = s.Stars.Count,
                    NumberOfComments = s.Comments.Count
                });

            if (stories.Count() == 0)
            {
                return Json(new { success = false, responseText = "No more stories." }, JsonRequestBehavior.AllowGet);
            }

            return this.PartialView("_StoriesPartial", stories);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return this.LoadPage(0);
            }

            var stories = this.storyService.Search(searchTerm).Select(
                s => new StoryShortViewModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImageUrl = s.MainImageUrl,
                    NumberOfStars = s.Stars.Count,
                    NumberOfComments = s.Comments.Count
                });
            return this.PartialView("_StoriesPartial", stories);
        }

        public ActionResult Details(Guid id)
        {
            var story = storyService.GetById(id);
            IEnumerable<string> imageUrls = null;
            if (story.ImageUrls != null && story.ImageUrls.Count > 0)
            {
                imageUrls = story.ImageUrls.Select(i => i.Url);
            }

            IEnumerable<CommentViewModel> storyComments = null;
            if (story.Comments != null && story.Comments.Count > 0)
            {
                storyComments = story.Comments
                    .Where(c => c.IsDeleted == false)
                    .OrderBy(c => c.PublishDate)
                    .Select(
                    c => new CommentViewModel()
                    {
                        UserFullName = c.UserId == null ? null : c.User.FirstName + " " + c.User.LastName,
                        UserId = c.UserId,
                        Comment = c.Content,
                        PublishDate = c.PublishDate
                    });
            }

            string starLinkClass = "fa-star-o";
            if (this.User.Identity.IsAuthenticated && this.storyService.HasUserStarred(id, this.User.Identity.GetUserId()))
            {
                starLinkClass = "fa-star";
            }

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
                    PublishDate = story.PublishDate,
                    ImageUrls = imageUrls,
                    NumberOfStars = story.Stars.Count,
                    StarLinkClass = starLinkClass,
                    Comments = storyComments,
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
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
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
        public ActionResult StarOrUnstar(Guid id)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, responseText = "Not authorized." }, JsonRequestBehavior.AllowGet);
            }

            int numberOfStars = this.storyService.StarOrUnstar(id, this.User.Identity.GetUserId());
            return this.Content(" " + numberOfStars.ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

            this.storyService.Comment(id, userId, commentContent);

            return this.PartialView("_CommentPartial", new CommentViewModel()
            {
                Comment = commentContent,
                UserFullName = userFullName,
                UserId = userId,
                PublishDate = DateTime.Now
            });
        }
    }
}