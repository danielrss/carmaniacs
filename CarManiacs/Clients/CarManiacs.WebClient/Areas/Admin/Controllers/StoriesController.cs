using CarManiacs.WebClient.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarManiacs.WebClient.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize(Roles = "Admin")]
    public class StoriesController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}