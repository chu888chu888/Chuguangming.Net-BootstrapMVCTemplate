using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;

namespace WebUtility.WebHelper
{
    public class RequestHelper
    {
        public RequestHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /**/
        /// <summary>
        /// 判断当前页面是否接收到了Post请求
        /// </summary>
        /// <returns>是否接收到了Post请求</returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }
        /**/
        /// <summary>
        /// 判断当前页面是否接收到了Get请求
        /// </summary>
        /// <returns>是否接收到了Get请求</returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /**/
        /// <summary>
        /// 返回指定的服务器变量信息
        /// </summary>
        /// <param name="strName">服务器变量名</param>
        /// <returns>服务器变量信息</returns>
        public static string GetServerString(string strName)
        {
            //
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }

        /**/
        /// <summary>
        /// 返回上一个页面的地址
        /// </summary>
        /// <returns>上一个页面的地址</returns>
        public static string GetUrlReferrer()
        {
            string retVal = null;

            try
            {
                retVal = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch { }

            if (retVal == null)
                return "";

            return retVal;

        }

        /**/
        /// <summary>
        /// 得到当前完整主机头
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
            {
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
            }
            return request.Url.Host;
        }

        /**/
        /// <summary>
        /// 得到主机头
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }


        /**/
        /// <summary>
        /// 获取当前请求的原始 URL(URL 中域信息之后的部分,包括查询字符串(如果存在))
        /// </summary>
        /// <returns>原始 URL</returns>
        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }

        /**/
        /// <summary>
        /// 判断当前访问是否来自浏览器软件
        /// </summary>
        /// <returns>当前访问是否来自浏览器软件</returns>
        public static bool IsBrowserGet()
        {
            string[] BrowserName = { "ie", "opera", "netscape", "mozilla" };
            string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < BrowserName.Length; i++)
            {
                if (curBrowser.IndexOf(BrowserName[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /**/
        /// <summary>
        /// 判断是否来自搜索引擎链接
        /// </summary>
        /// <returns>是否来自搜索引擎链接</returns>
        public static bool IsSearchEnginesGet()
        {
            string[] SearchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom" };
            string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < SearchEngine.Length; i++)
            {
                if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /**/
        /// <summary>
        /// 获得当前完整Url地址
        /// </summary>
        /// <returns>当前完整Url地址</returns>
        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }


        /**/
        /// <summary>
        /// 获得指定Url参数的值
        /// </summary>
        /// <param name="strName">Url参数</param>
        /// <returns>Url参数的值</returns>
        public static string GetQueryString(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.QueryString[strName];
        }

        /**/
        /// <summary>
        /// 获得当前页面的名称
        /// </summary>
        /// <returns>当前页面的名称</returns>
        public static string GetPageName()
        {
            string[] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            return urlArr[urlArr.Length - 1].ToLower();
        }

        /**/
        /// <summary>
        /// 返回表单或Url参数的总个数
        /// </summary>
        /// <returns></returns>
        public static int GetParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }


        /**/
        /// <summary>
        /// 获得指定表单参数的值
        /// </summary>
        /// <param name="strName">表单参数</param>
        /// <returns>表单参数的值</returns>
        public static string GetFormString(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Form[strName];
        }

        /**/
        /// <summary>
        /// 获得Url或表单参数的值, 先判断Url参数是否为空字符串, 如为True则返回表单参数的值
        /// </summary>
        /// <param name="strName">参数</param>
        /// <returns>Url或表单参数的值</returns>
        public static string GetString(string strName)
        {
            if ("".Equals(GetQueryString(strName)))
            {
                return GetFormString(strName);
            }
            else
            {
                return GetQueryString(strName);
            }
        }













        /**/
        /// <summary>
        /// 获得当前页面客户端的IP
        /// </summary>
        /// <returns>当前页面客户端的IP</returns>
        public static string GetIP()
        {


            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            if (null == result || result == String.Empty)
            {
                return "0.0.0.0";
            }

            return result;

        }

        /**/
        /// <summary>
        /// 保存用户上传的文件
        /// </summary>
        /// <param name="path">保存路径</param>
        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }
        public static string GetUrlAddressInfo(string strWebAddress,int intReturnLegth)
        {
            //创建WebRequest请求
            WebRequest request = WebRequest.Create(strWebAddress);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string Htmlstring = reader.ReadToEnd();

            //判断编码
            int h = Htmlstring.IndexOf("charset=") + 8;

            string encoding = Htmlstring.Substring(h, Htmlstring.Substring(h).IndexOf("\""));
            encoding = Regex.Replace(encoding, "\"", "", RegexOptions.IgnoreCase);
            WebRequest request2 = WebRequest.Create(strWebAddress);
            WebResponse response2 = request2.GetResponse();
            StreamReader reader2 = new StreamReader(response2.GetResponseStream(), Encoding.GetEncoding(encoding));
            Htmlstring = reader2.ReadToEnd();

            //网页内容提取


            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>[\w\W]*?</script>", "", RegexOptions.IgnoreCase);// 清除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<style[^>]*?>[\w\W]*?</style>", "", RegexOptions.IgnoreCase);// 清除样式
            Htmlstring = Regex.Replace(Htmlstring, @"<noscript[^>]*?>[\w\W]*?</noscript>", "", RegexOptions.IgnoreCase);// 清除非脚本

            Htmlstring = Regex.Replace(Htmlstring, @"<a[^>]*?>[\w\W]*?</a>", "", RegexOptions.IgnoreCase);// 清除超连接

            Htmlstring = Regex.Replace(Htmlstring, @"<!--[\w\W]*?-->", "", RegexOptions.IgnoreCase);// 清除注释
            Htmlstring = Regex.Replace(Htmlstring, @"<img.*?>", "", RegexOptions.IgnoreCase);// 清除IMG
            Htmlstring = Regex.Replace(Htmlstring, @"<table.*?>", "", RegexOptions.IgnoreCase);// 清除td
            Htmlstring = Regex.Replace(Htmlstring, @"</table>", "", RegexOptions.IgnoreCase);// 清除td
            Htmlstring = Regex.Replace(Htmlstring, @"<tr.*?>", "", RegexOptions.IgnoreCase);// 清除td
            Htmlstring = Regex.Replace(Htmlstring, @"</tr>", "", RegexOptions.IgnoreCase);// 清除td
            Htmlstring = Regex.Replace(Htmlstring, @"<a.*?>", "", RegexOptions.IgnoreCase);// 清除td
            Htmlstring = Regex.Replace(Htmlstring, @"</a>", "", RegexOptions.IgnoreCase);// 清除td
            Htmlstring = Regex.Replace(Htmlstring, @"<td.*?>", "", RegexOptions.IgnoreCase);// 清除td
            Htmlstring = Regex.Replace(Htmlstring, @"</strong>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<strong>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"</td>", "", RegexOptions.IgnoreCase);// 清除td
            Htmlstring = Regex.Replace(Htmlstring, @"<div.*?>", "", RegexOptions.IgnoreCase);// 清除div
            Htmlstring = Regex.Replace(Htmlstring, @"</div>", "", RegexOptions.IgnoreCase);// 清除td
            Htmlstring = Regex.Replace(Htmlstring, "<[^>]*>", "");//清除所有<中>的标签

            Htmlstring = Regex.Replace(Htmlstring, "&nbsp;", "", RegexOptions.IgnoreCase);//清楚特殊符号 &nbsp; 
            Htmlstring = Regex.Replace(Htmlstring, "&gt;", "", RegexOptions.IgnoreCase);//清楚特殊符号 &gt;
            Htmlstring = Regex.Replace(Htmlstring, "&ldquo;", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&rdquo;", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, "\r\n", "<1>", RegexOptions.IgnoreCase);//清楚空格
            Htmlstring = Regex.Replace(Htmlstring, "\n", "<1>", RegexOptions.IgnoreCase);//清楚空格
            Htmlstring = Regex.Replace(Htmlstring, "\t", "<1>", RegexOptions.IgnoreCase);//清楚空格

            string con = null;
            int su = 20;//定义段落长度

            for (; ; )
            {
                int s = Htmlstring.IndexOf("<1>") + 3;
                int t = Htmlstring.Substring(s).IndexOf("<1>");
                string c = Htmlstring.Substring(s, t);
                Htmlstring = Htmlstring.Substring(s + t);

                if (c.Length > su)
                {
                    con += c;
                }
                if (Htmlstring.Length < su)
                {
                    break;
                }
            }
            reader.Close();
            reader.Dispose();
            response.Close();
            //网页内容提取
            //去除空格
            string returndata = Regex.Split(con, @" +").ToString();
            return con.Trim().Substring(0, intReturnLegth);
        }


    }

}
