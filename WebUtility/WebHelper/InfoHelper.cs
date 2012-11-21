using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace WebUtility.WebHelper
{
    public static class InfoHelper
    {
        /// <summary>
        /// 获得客户IP
        /// </summary>
        /// <returns></returns>
        public static string GetRemoteIP()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
        /// <summary>
        /// 获得客户浏览器
        /// </summary>
        /// <returns></returns>
        public static string GetRemoteAgent()
        {
            return HttpContext.Current.Request.UserAgent;
        }
        /// <summary>
        /// 获得客户名称
        /// </summary>
        /// <returns></returns>
        public static string GetRemoteName()
        {
            return HttpContext.Current.Request.UserHostName;
        }
        /// <summary>
        /// 获得客户端语言
        /// </summary>
        /// <returns></returns>
        public static string [] GetRemoteLang()
        {
            return HttpContext.Current.Request.UserLanguages;
        }
        /// <summary>
        /// 获得客户的URL
        /// </summary>
        /// <returns></returns>
        public static string GetURL()
        {
            return HttpContext.Current.Request.UrlReferrer.ToString();
        }
    }
}
