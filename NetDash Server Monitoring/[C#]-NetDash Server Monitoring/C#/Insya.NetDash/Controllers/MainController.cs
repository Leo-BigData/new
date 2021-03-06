// Copyright (c) 2014, Insya Interaktif.
// Developer @yasinkuyu
// All rights reserved.

using System.Web.Mvc;

namespace Insya.NetDash.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Version()
        {
            return Content(Functions.CurrentVersion);
        }
    }
}
