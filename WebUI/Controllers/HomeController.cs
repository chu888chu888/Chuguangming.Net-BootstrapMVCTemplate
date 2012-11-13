using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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
            ViewBag.UserID = this.HttpContext.User.Identity.Name;
            
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult VIP()
        {
            return View();
        }
    }
}
