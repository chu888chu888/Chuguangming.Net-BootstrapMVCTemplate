using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBusiness.AccountBusiness;

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
                if (AccountOperation.LoginCheck(model.Email,model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
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
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(WebUI.Models.AccountModels.RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //实现注册
                if (AccountOperation.RegisterUser(model.UserName,model.Password,model.Email))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Manager", "Home");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }
        public ActionResult ForgetPassWord()
        {
            return View();
        }

    }
}
