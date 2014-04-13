using ControllerInjection.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//http://www.codeproject.com/Articles/560798/ASP-NET-MVC-Controller-Dependency-Injection-for-Be

namespace ControllerInjection.Controllers
{
    public  class HomeController : Controller
    {       
        private readonly ILogger _logger;     

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }
        [Authorize]
        public virtual ActionResult Index()
        {
            _logger.Log("Hello");
            return View("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}