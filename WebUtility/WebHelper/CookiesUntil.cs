using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Reflection;
namespace WebUtility.WebHelper
{
    public class CookiesUntil
    {
        public CookiesUntil()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static string GetRequestString(HttpRequest req, string val)
        {
            string[] arr = req.QueryString.GetValues(val);
            if (arr == null)
                arr = req.Form.GetValues(val);
            if (arr != null)
                return arr[0];
            else
                return null;
        }
        public static int GetRequestInt(HttpRequest req, string val)
        {
            string[] arr = req.QueryString.GetValues(val);
            if (arr == null)
                arr = req.Form.GetValues(val);
            if (arr != null)
                return StringToInt(arr[0]);
            else
                return 0;
        }
        public static string GetCookiesString(HttpRequest req, string CookiesName)
        {
            if (req.Cookies[CookiesName] != null)
                return req.Cookies[CookiesName].Value;
            else
                return null;
        }
        public static int GetCookiesInt(HttpRequest req, string CookiesName)
        {
            if (req.Cookies[CookiesName] != null)
                return StringToInt(req.Cookies[CookiesName].Value);
            else
                return 0;
        }
        public static bool SetCookies(HttpResponse res, string cookname, int cookval)
        {

            try
            {
                HttpCookie cook = new HttpCookie(cookname, cookval.ToString());
                res.Cookies.Add(cook);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SetCookies(HttpResponse res, string cookname, string cookval)
        {

            try
            {
                HttpCookie cook = new HttpCookie(cookname, cookval);
                res.Cookies.Add(cook);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static int StringToInt(string val)
        {
            try
            {
                return Int32.Parse(val);
            }
            catch
            {
                return 0;
            }
        }
    }
}