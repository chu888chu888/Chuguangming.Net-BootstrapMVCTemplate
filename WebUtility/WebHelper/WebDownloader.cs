using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
namespace WebUtility.WebHelper
{
    class WebDownloader
    {
        /// <summary>
        /// 下载指定的网页
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DownLoadHtml(string url)
        {
            string output = "";
            Encoding encode = Encoding.Default;
            WebClient webclient = new WebClient();
            try
            {
                webclient.Headers.Add("Referer", url);
                byte[] buff = webclient.DownloadData(url);
                output = encode.GetString(buff);
            }
            catch
            {
            }
            return output;
        }

        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RepalceStr(string str)
        {
           
            str = str.Replace("\r\n", "");
            str = str.Replace("\"", "");
            str = str.Replace("：", "");
            str = str.Replace("\t", "");
            str = str.Replace("&nbsp;", "");
            str = str.Replace("'", "");
            str = str.Replace("\r", "");
            str = str.Replace("\n", "");
            return str;
        }

        /// <summary>
        /// 即从目标字符串的第begin个字符处开始，读取以 strBegin 开头,
        /// strEnd 结束的字符串.并返回获取到的内容，如果不存在，返回空。
        /// </summary>
        /// <param name="strTarget"></param>
        /// <param name="strBegin"></param>
        /// <param name="strEnd"></param>
        /// <param name="begin"></param>
        /// <returns></returns>
        public static string GetHTMLContent(string strTarget, string strBegin, string strEnd, ref int begin)
        {
            string result;
            int posBegin, posEnd;
            posBegin = strTarget.IndexOf(strBegin, begin);
            if (posBegin != -1)
            {
                posEnd = strTarget.IndexOf(strEnd, posBegin + strBegin.Length);
                if (posEnd > posBegin)
                {
                    result = strTarget.Substring(posBegin, posEnd + strEnd.Length - posBegin);
                    begin = posEnd + strEnd.Length;
                    return result;

                }
            }
            begin = -1;
            return "";
        }

    }
}
