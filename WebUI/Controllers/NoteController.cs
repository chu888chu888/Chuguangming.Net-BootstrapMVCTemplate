using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBusiness.NoteBusiness;
using Webdiyer.WebControls.Mvc;
using WebUI.Models;

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
            if (NoteOperation.PostNote(fmd.PosterTitle, fmd.Content,HttpContext.User.Identity.Name) == true)
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
        public ActionResult BrowseAll(int id = 1)
        {
            using (var db = new SNSDBEntities())
            {
                PagedList<SNS_Note> orders = db.SNS_Note.OrderByDescending(o => o.SNS_Note_Date).ToPagedList(id, 30);
                return View(orders);
            }
        }

    }
}
