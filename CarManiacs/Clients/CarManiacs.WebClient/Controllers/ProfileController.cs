using System.Web.Mvc;

namespace CarManiacs.WebClient.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}