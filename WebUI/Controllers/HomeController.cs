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
            //ViewBag.UserID = this.HttpContext.User.Identity.Name;
            ViewBag.UserID = "欢迎您使用友学视频系统";

            Dictionary<string, string> Dictclassify = new Dictionary<string, string>();
            Dictclassify.Add("1", "分享电影");
            Dictclassify.Add("2", "好听音乐");
            Dictclassify.Add("3", "好玩图片");
            Dictclassify.Add("4", "分享图书");
            Dictclassify.Add("5", "无限下载");
            ViewBag.classify = Dictclassify;

            List<Dictionary<string, string>> ImageSrcDatasource = new List<Dictionary<string, string>>();
            Dictionary<string, string> imageDetailDict;
            for (int i = 1; i <= 36; i++)
            {
                imageDetailDict = new Dictionary<string, string>();
                imageDetailDict.Add("BigImagePath",string.Format("{0}.jpg",i.ToString()));
                imageDetailDict.Add("SmallImagePath",string.Format("{0}.jpg",i.ToString()));
                imageDetailDict.Add("ImageTitle","这是一个测试");
                imageDetailDict.Add("ImageDetail","XXXXXXX");
                ImageSrcDatasource.Add(imageDetailDict);
            }
            ViewBag.ImageDatasource = ImageSrcDatasource;

            

            return View();
        }
        public ActionResult Detail(int id)
        {
            ViewBag.DetailID = id;
            return View();
        }
        public ActionResult Manager()
        {
            //ViewBag.UserID = this.HttpContext.User.Identity.Name;
            ViewBag.UserID = "欢迎您使用友学视频系统";

            Dictionary<string, string> Dictclassify = new Dictionary<string, string>();
            Dictclassify.Add("1", "分享电影");
            Dictclassify.Add("2", "好听音乐");
            Dictclassify.Add("3", "好玩图片");
            Dictclassify.Add("4", "分享图书");
            Dictclassify.Add("5", "无限下载");
            ViewBag.classify = Dictclassify;



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
