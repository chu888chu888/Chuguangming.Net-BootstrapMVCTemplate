using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace WebUtility.WebHelper
{
    public static class InfoHelper
    {
        /// <summary>
        /// ��ÿͻ�IP
        /// </summary>
        /// <returns></returns>
        public static string GetRemoteIP()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
        /// <summary>
        /// ��ÿͻ������
        /// </summary>
        /// <returns></returns>
        public static string GetRemoteAgent()
        {
            return HttpContext.Current.Request.UserAgent;
        }
        /// <summary>
        /// ��ÿͻ�����
        /// </summary>
        /// <returns></returns>
        public static string GetRemoteName()
        {
            return HttpContext.Current.Request.UserHostName;
        }
        /// <summary>
        /// ��ÿͻ�������
        /// </summary>
        /// <returns></returns>
        public static string [] GetRemoteLang()
        {
            return HttpContext.Current.Request.UserLanguages;
        }
        /// <summary>
        /// ��ÿͻ���URL
        /// </summary>
        /// <returns></returns>
        public static string GetURL()
        {
            return HttpContext.Current.Request.UrlReferrer.ToString();
        }
    }
}
