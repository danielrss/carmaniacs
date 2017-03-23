using System.Web.Mvc;

namespace CarManiacs.WebClient.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}