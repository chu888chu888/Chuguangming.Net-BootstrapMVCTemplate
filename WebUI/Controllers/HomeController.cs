using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Title = "ASP.NET MVC 4 Web Template";
            return View();
        }
        public ActionResult Manager()
        {
            return View();
        }
    }
}
