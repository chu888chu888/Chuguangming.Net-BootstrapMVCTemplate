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
        public ActionResult LogOn(WebUI.Models.AccountModels.LogOnModel model, string CaptchaValue)
        {
            bool cv = CaptchaController.IsValidCaptchaValue(CaptchaValue.ToUpper());
            if (!cv)
            {
                ModelState.AddModelError(string.Empty, "验证码错误");
                return View();
            }
            if (ModelState.IsValid)
            {
                if (AccountOperation.LoginCheck(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(AccountOperation.GetUserID(model.Email, model.Password), true);

                    return RedirectToAction("Manager", "Index");
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
                string guid = Guid.NewGuid().ToString();
                if (AccountOperation.RegisterUser(guid, model.UserName, model.Password, model.Email))
                {
                    FormsAuthentication.SetAuthCookie(guid, true);
                    HttpCookie cookie = FormsAuthentication.GetAuthCookie(guid, true);
                    cookie.Expires = DateTime.Today.AddMonths(1);
                    Response.Cookies.Add(cookie);


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
