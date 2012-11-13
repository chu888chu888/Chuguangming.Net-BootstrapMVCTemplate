using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBusiness.NoteBusiness;

namespace WebUI.Controllers
{
    public class NoteController : Controller
    {
        public ActionResult Append()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Append(WebUI.Models.NoteModels.FMNote fmd)
        {
            if (this.ModelState.IsValid == false)
            { return View(); }
            if (NoteOperation.PostNote(fmd.PosterTitle, fmd.Content,Session["PosterID"].ToString()) == true)
            {
                return RedirectToAction("BrowseAll");
            }
            else
            {
                this.ModelState.AddModelError("FailedMess", "发表失败！");
                return View();
            }
        }
        /* 因为首页就分页, 但我们一般首页没有页数参数, 所以用一个可空类型 */
        public ActionResult BrowseAll()
        {
            return View();
        }
    }
}
