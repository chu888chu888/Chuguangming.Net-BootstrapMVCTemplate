using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOn(WebUI.Models.AccountModels.LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == "chu888chu888@gmail.com" && model.Password == "2711632")
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);

                        Session["UserName"] = model.Email;
                        return RedirectToAction("Manager", "Home");
                }
            }

            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View();
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
