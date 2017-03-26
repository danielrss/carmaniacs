using CarManiacs.Business.Services.Contracts;

using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace CarManiacs.WebClient.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (this.Request.HttpMethod == "GET" && this.User.Identity.IsAuthenticated)
            {
                if (this.HttpContext.Session["AvatarUrl"] == null)
                {
                    IRegularUserService regularUserService = DependencyResolver.Current.GetService(typeof(IRegularUserService)) as IRegularUserService;
                    Guard.WhenArgument(regularUserService, "regularUserService").IsNull().Throw();

                    string avatarUrl = regularUserService.GetById(this.User.Identity.GetUserId()).AvatarUrl;
                    this.HttpContext.Session["AvatarUrl"] = avatarUrl;
                    this.ViewBag.AvatarUrl = avatarUrl;
                }
                else
                {
                    this.ViewBag.AvatarUrl = this.HttpContext.Session["AvatarUrl"].ToString();
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}