using System.Web.Mvc;

namespace CarManiacs.WebClient.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}