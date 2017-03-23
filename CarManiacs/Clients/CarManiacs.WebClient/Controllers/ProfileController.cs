using Bytes2you.Validation;
using CarManiacs.Business.Services.Contracts;
using CarManiacs.DTOs;
using CarManiacs.WebClient.ActionFilters;
using CarManiacs.WebClient.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace CarManiacs.WebClient.Controllers
{
    public class ProfileController : BaseController
    {
        private IRegularUserService regularUserService;

        public ProfileController(IRegularUserService userService)
        {
            Guard.WhenArgument(userService, "regularUserService").IsNull().Throw();

            this.regularUserService = userService;
        }

        public ActionResult Details(string id)
        {
            var user = regularUserService.GetById(id);
            if (user != null)
            {
                var viewModel = new ProfileDetailsViewModel()
                {
                    CarManiacForDays = (int)(DateTime.Now - user.RegisterDate).TotalDays,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsAllowedToEdit = this.User.Identity.GetUserId() == user.Id
                };
                return View(viewModel);
            }

            return new HttpNotFoundResult();
        }
        
        [Authorize]
        [HttpGet]
        public ActionResult Edit()
        {
            var user = regularUserService.GetById(this.User.Identity.GetUserId());

            var viewModel = new ProfileEditViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [Transaction]
        public ActionResult Edit(ProfileEditViewModel model)
        {
            var updatedUser = new RegularUserDto()
            {
                Id = this.User.Identity.GetUserId(),
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            this.regularUserService.Update(updatedUser);

            return this.RedirectToAction("Details", "Profile", new { id = this.User.Identity.GetUserId() });
        }
    }
}