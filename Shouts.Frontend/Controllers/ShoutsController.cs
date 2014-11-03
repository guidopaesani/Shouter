using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shouts.Domain.Abstract;
using Shouts.Frontend.Infrastructure.Concrete;
using Shouts.Frontend.Models;
using Shouts.Frontend.Models.Shouts;
using Shouts.Frontend.Service;
using Shouts.Storage.Repositories.Concrete;
using Shout = Shouts.Domain.Shout;


namespace Shouts.Frontend.Controllers
{
    [Authorize]
    public class ShoutsController : Controller
    {
        private IShoutsRepository _repository;
        //
        // GET: /Shouts/
        public ShoutsController() : this(new ShoutsRepository())
        {}

        public ShoutsController(IShoutsRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Post(string newShoutContent)
        {
          //Validate post
          //Save Post in Repository
            Domain.Shout newShout = new Domain.Shout(User.Identity.Name, newShoutContent, DateTime.Now);
            _repository.AddShout(newShout);
            //Reload Shouts Page
            return RedirectToAction("Index");
        }
        
        public PartialViewResult GetShoutList()
        {
            List<Domain.Shout> originalShouts = new List<Domain.Shout>();
            originalShouts = _repository.GetShoutsByUser(User.Identity.Name);
            ShoutTimeFormatter shoutsFormatter = new ShoutTimeFormatter(originalShouts);
            List<Shouts.Frontend.Models.Shouts.Shout> convertedShouts = shoutsFormatter.ConvertShoutList();
            return PartialView("ShoutList", convertedShouts);
            
        }
	}
}