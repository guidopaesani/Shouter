using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Shouts.Frontend.Models.Account;
using Shouts.Frontend.Infrastructure.Abstract;
using Shouts.Frontend.Infrastructure.Concrete;
using System.Web.Security;
using Shouts.Storage.Repositories.Concrete;

namespace Shouts.Frontend.Controllers
{
    public class AccountController : Controller
    {
        private IAuthorization _authorizationProvider;
        
        public AccountController() : this(new DatabaseAuthorization(new AuthorizationRepository()))
        { }
        
        public AccountController(IAuthorization authorizationProvider)
        {
            _authorizationProvider = authorizationProvider;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (_authorizationProvider.Login(model.Email, model.Password))
            {
                return RedirectToAction("Index", "Shouts");
            }
            ModelState.AddModelError("loginError", "Login not valid!");
            return View();
        }

        public ActionResult Logoff()
        {
            _authorizationProvider.Logoff();
            return RedirectToAction("Index", "Home");
        }
	}
}