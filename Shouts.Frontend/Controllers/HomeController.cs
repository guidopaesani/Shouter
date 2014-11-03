using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shouts.Frontend.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        { }
        
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Shouts");
            return RedirectToAction("Login", "Account");
        }
    }
}