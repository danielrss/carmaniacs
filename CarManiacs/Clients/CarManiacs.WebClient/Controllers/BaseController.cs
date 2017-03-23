using CarManiacs.Business.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace CarManiacs.WebClient.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                if (this.HttpContext.Cache["AvatarUrl"] == null)
                {
                    var usermanager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    string avatarUrl = usermanager.FindById(User.Identity.GetUserId()).AvatarUrl;
                    this.HttpContext.Cache["AvatarUrl"] = avatarUrl;
                    this.ViewBag.AvatarUrl = avatarUrl;
                }
                else
                {
                    this.ViewBag.AvatarUrl = this.HttpContext.Cache["AvatarUrl"].ToString();
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}