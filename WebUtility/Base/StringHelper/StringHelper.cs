using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
namespace WebUtility.Base.StringHelper
{

    /// <summary>
    /// StringHelper 的摘要说明
    /// </summary>
    public class StringHelper
    {
        public StringHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 删除特殊字符
        /// <summary>
        /// 删除特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DelQuota(string str)
        {
            string result = str;
            string[] strQuota ={ "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "`", ";", "'", ",", ".", "/", ":", "/,", "<", ">", "?" };
            for (int i = 0; i < strQuota.Length; i++)
            {
                if (result.IndexOf(strQuota[i]) > -1)
                    result = result.Replace(strQuota[i], "");
            }
            return result;
        }
        #endregion
        #region 删除HTML
        public static string DelHtml(string str)
        {
            string result = str;
            string[] strQuota = { "h1", "<b>", "<p>", "<li>", "<ul>", "<html>", "img" };
            for (int i = 0; i < strQuota.Length; i++)
            {
                if (result.IndexOf(strQuota[i]) > -1)
                    result = result.Replace(strQuota[i], "");
            }
            return result;
        }
        #endregion
        #region 删除字符串中的javascript代码
        /// <summary>
        /// 删除字符串中的javascript代码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FilterJS(string str)
        {
            Regex re = new Regex("&#36;", RegexOptions.IgnoreCase);
            str = re.Replace(str, "$");
            re = new Regex("&#36", RegexOptions.IgnoreCase);
            str = re.Replace(str, "$");
            re = new Regex("&#39;", RegexOptions.IgnoreCase);
            str = re.Replace(str, "'");
            re = new Regex("&#39", RegexOptions.IgnoreCase);
            str = re.Replace(str, "'");

            string jslist = @"(&#([0-9][0-9]*)|function|meta|window.|script|js:|about:|file:|Document.|vbs:|frame|cookie|on(finish|mouse|Exit=|error|click|key|load|focus|Blur))";
            re = new Regex("<((.[^>]*" + jslist + "[^>]*)|" + jslist + ")>", RegexOptions.IgnoreCase);
            str = re.Replace(str, "&lt;$1&gt;");

            return str;
        }
        #endregion
        #region 对于不完整的Html标签加入完整的标签
        /// <summary>
        /// 对于不完整的Html标签加入完整的标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string closeHTML(string str)
        {
            string[] HtmlTag = new string[] { "p", "div", "span", "table", "ul", "font", "b", "u", "i", "a", "h1", "h2", "h3", "h4", "h5", "h6" };

            for (int i = 0; i < HtmlTag.Length; i++)
            {
                int OpenNum = 0, CloseNum = 0;
                Regex re = new Regex("<" + HtmlTag[i] + "[^>]*" + ">", RegexOptions.IgnoreCase);
                MatchCollection m = re.Matches(str);
                OpenNum = m.Count;
                re = new Regex("</" + HtmlTag[i] + ">", RegexOptions.IgnoreCase);
                m = re.Matches(str);
                CloseNum = m.Count;

                for (int j = 0; j < OpenNum - CloseNum; j++)
                {
                    str += "</" + HtmlTag[i] + ">";
                }
            }

            return str;
        }
        #endregion
        #region 升级身份证号15到18位
        /// <summary>
        /// 升级身份证号15到18位
        /// </summary>
        /// <param name="sfzh"></param>
        /// <returns></returns>
        public static string getCheckCode15To18(string sfzh)
        {
                char[] strJiaoYan = {'1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2'};
                int[] intQuan = {7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2, 1};
                string strTemp;
                int intTemp = 0;

                strTemp = sfzh.Substring(0,6) + "19" + sfzh.Substring(6);
                for (int i=0;i<=strTemp.Length-1;i++)
                {
                intTemp += int.Parse(strTemp.Substring(i,1))*intQuan[i];
                }
                intTemp = intTemp % 11;
                return strTemp + strJiaoYan[intTemp];
            }
        #endregion
        #region 检查身份证的正确性
            /// <summary>
        /// 检查身份证的正确性
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public static string CheckCidInfo(string cid) 
            { 
                string[] aCity = new string[]{null,null,null,null,null,null,null,null,null,null,null,"北京","天津","河北","山西","内蒙古",null,null,null,null,null,"辽宁","吉林","黑龙江",null,null,null,null,null,null,null,"上海","江苏","浙江","安微","福建","江西","山东",null,null,null,"河南","湖北","湖南","广东","广西","海南",null,null,null,"重庆","四川","贵州","云南","西藏",null,null,null,null,null,null,"陕西","甘肃","青海","宁夏","新疆",null,null,null,null,null,"台湾",null,null,null,null,null,null,null,null,null,"香港","澳门",null,null,null,null,null,null,null,null,"国外"}; 
                double iSum=0; 
                System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^\d{17}(\d|x)$"); 
                System.Text.RegularExpressions.Match mc = rg.Match(cid); 
                if(!mc.Success) 
                { 
                return ""; 
                } 
                cid = cid.ToLower(); 
                cid = cid.Replace("x","a"); 
                if(aCity[int.Parse(cid.Substring(0,2))]==null) 
                { 
                return "非法地区"; 
                } 
                try 
                { 
                DateTime.Parse(cid.Substring(6,4)+"-"+cid.Substring(10,2)+"-"+cid.Substring(12,2)); 
                } 
                catch 
                { 
                return "非法生日"; 
                } 
                for(int i=17;i>=0;i--) 
                { 
                iSum +=(System.Math.Pow(2,i)%11)*int.Parse(cid[17-i].ToString(),System.Globalization.NumberStyles.HexNumber); 


                } 
                if(iSum%11!=1) 
                return("非法证号"); 


                return(aCity[int.Parse(cid.Substring(0,2))]+","+cid.Substring(6,4)+"-"+cid.Substring(10,2)+"-"+cid.Substring(12,2)+","+(int.Parse(cid.Substring(16,1))%2==1?"男":"女"));


            }
            #endregion
        #region 截取新闻的前16个字
        public static string SubTitle(object s)
        {
            if (s.ToString().Length > 16)
                return s.ToString().Substring(0, 16) + "...";
            else
                return s.ToString() + "...";
        }
        #endregion
        #region 过滤不良字符
        public static string FilterBadWords(string msg)
        {
            string badwords = "妈妈的|我靠|操|fuck|sb|bitch|他妈的|性爱|操你妈|三级片|sex|腚|妓|娼|阴蒂|奸|尻|贱|婊|靠|叉|龟头|屄|赑|妣|肏|尻|屌";
            string[] tempstr = badwords.Split('|');
            string finalstr = msg;
            for (int i = 0; i < tempstr.Length; i++)
            {
                finalstr = finalstr.Replace(tempstr[i], new String('*', tempstr[i].Length));
            }
            return finalstr;

        }
        #endregion
                #region 对字符串进行HTML编码，针对(input,Textarea)输入时过滤脚本及HTML编码
        /**//// <summary>
        /// 对字符串进行HTML编码，针对(input,Textarea)输入时过滤脚本及HTML编码
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static string EncodeToHtml(string source)
        {
            source = source.Trim();            
            source = source.Replace("'","''");
            source = source.Replace("\\","＼");
            source = System.Web.HttpContext.Current.Server.HtmlEncode(source);
            source = source.Replace("\r\n","<br>");
            source = source.Replace("\n","<br>");
            return source;
        }


        #region [否决的]对字符串进行HTML编码，针对(input,Textarea)输入时过滤脚本及HTML编码
        /// <summary>
        /// [否决的]对字符串进行HTML编码，针对(input,Textarea)输入时过滤脚本及HTML编码 (不符合命名规范，请使用 EncodeToHtml 方法 )
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static string HtmlFilterForInput(string source)
        {
            return EncodeToHtml(source);
        }


        #region 还原HTML编码为字符串,还原HTML编码为字符串，用于返回到input或 Textarea 输入框
        /**//// <summary>
        /// 还原HTML编码为字符串，用于返回到input或 Textarea 输入框
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static string DecodeFormHtml(string source)
        {                                                    
            source = source.Trim();                                
            source = source.Replace("<br>","\r\n");                
            source = source.Replace("<br>","\n");                    
            source    = System.Web.HttpContext.Current.Server.HtmlDecode(source);               
            return source;                                      
        }


        #region [否决的]还原HTML编码为字符串,还原HTML编码为字符串，用于返回到input或 Textarea 输入框
        /**//// <summary>
        /// [否决的]还原HTML编码为字符串，用于返回到input或 Textarea 输入框 (不符合命名规范，请使用 DecodeFormHtml 方法 )
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static string DeHtmlFilterForInput(string source)
        {
            source = source.Trim();                                
            source = source.Replace("<br>","\r\n");                
            source = source.Replace("<br>","\n");                    
            source    = System.Web.HttpContext.Current.Server.HtmlDecode(source);               
            return source;
        }


        #region 检验用户提交的URL参数字符里面是否有非法字符
        /// <summary>
        /// 检验用户提交的URL参数字符里面是否有非法字符,如果有则返回True.防止SQL注入.
        /// </summary>
        /// <param name="str">(string)</param>
        /// <returns>bool</returns>
        public static bool VerifyString(string str)
        {
            string strTmp=str.ToUpper();
            if(strTmp.IndexOf("SELECT ")>=0 || strTmp.IndexOf(" AND ")>=0 || strTmp.IndexOf(" OR ")>=0 ||
                strTmp.IndexOf("EXEC ")>=0 || strTmp.IndexOf("CHAR(")>=0)
            {
                return true;
            }
                
            strTmp.Replace("'","＇").Replace(";","；");
            return false;
        }

        #endregion


        #region 过滤 Sql 语句字符串中的注入脚本
        /// <summary>
        /// 过滤 Sql 语句字符串中的注入脚本
        /// </summary>
        /// <param name="source">传入的字符串</param>
        /// <returns></returns>
        #endregion    
        public static string FilterSql(string source)
        {
            //单引号替换成两个单引号
            source = source.Replace("'","''");

            //半角封号替换为全角封号，防止多语句执行
            source = source.Replace(";","；");

            //半角括号替换为全角括号
            source = source.Replace("(","（");
            source = source.Replace(")","）");

            /**////////////////要用正则表达式替换，防止字母大小写得情况////////////////////

            //去除执行存储过程的命令关键字
            source = source.Replace("Exec","");
            source = source.Replace("Execute","");

            //去除系统存储过程或扩展存储过程关键字
            source = source.Replace("xp_","x p_");
            source = source.Replace("sp_","s p_");

            //防止16进制注入
            source = source.Replace("0x","0 x");

            return source;
        }


        #region [否决的]过滤 Sql 语句字符串中的注入脚本
        /// <summary>
        /// [否决的]过滤 Sql 语句字符串中的注入脚本(请使用 FilterSql 方法 )
        /// </summary>
        /// <param name="source">传入的字符串</param>
        /// <returns></returns>
        #endregion    
        public static string SqlFilter(string source)
        {
            return FilterSql(source);
        }

            
        #region 过滤字符串只剩数字
        /// <summary>
        /// 过滤字符串只剩数字
        /// </summary>
        /// <param name="source">源字符串</param>
        #endregion    
        public static string FilterToNumber(string source)
        {
            source =  Regex.Replace (source,"[^0-9]*","",System.Text.RegularExpressions.RegexOptions.IgnoreCase );            
            return source;
        }


        #region [否决的]过滤字符串只剩数字
        /**//// <summary>
        /// [否决的]过滤字符串只剩数字(请使用 FilterToNumber 方法)
        /// </summary>
        /// <param name="source">源字符串</param>
        #endregion    
        public static string NumberFilter(string source)
        {
            source =  Regex.Replace (source,"[^0-9]*","",System.Text.RegularExpressions.RegexOptions.IgnoreCase );            
            return source;
        }


        #region 去除数组内重复元素
        /// <summary>
        /// 去除数组内重复元素
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        #endregion
        public ArrayList FilterRepeatArrayItem(ArrayList arr)
        {
            //建立新数组
            ArrayList newArr = new ArrayList();
            
            //载入第一个原数组元素
            if(arr.Count>0)
            {
                newArr.Add(arr[0]);
            }

            //循环比较
            for(int i=0;i<arr.Count;i++)
            {
                if(!newArr.Contains(arr[i]))
                {
                    newArr.Add(arr[i]);
                }                    
            }
            return newArr;
        }


        #region 在最后去除指定的字符
        /// <summary>
        /// 在最后去除指定的字符
        /// </summary>
        /// <param name="source">参加处理的字符</param>
        /// <param name="cutString">要去除的字符</param>
        /// <returns>返回结果</returns>
        #endregion    
        public static string CutLastString(string source, string cutString)
        {
            string result ="";
            int tempIndex=0;

            tempIndex = source.LastIndexOf(cutString);
            if(cutString.Length==(source.Length-tempIndex))
            {
                result = source.Substring(0,tempIndex);
            }
            else
            {
                result = source;
            }
                    
            return result;
        }


        #region 利用正则表达式实现UBB代码转换为html代码
        /// <summary>
        /// 利用正则表达式实现UBB代码转换为html代码
        /// </summary>
        /// <param name="source">待处理的文本内容</param>
        /// <returns>返回正确的html代码</returns>
        #endregion
        public static string UBBCode(string source)
        {
            if(source==null || source.Length==0)
            {
                return "";
            }
                
            source=source.Replace("&nbsp;","");
            //source=source.Replace("<","&lt");
            //source=source.Replace(">","&gt");
            source=source.Replace("\n","<br>");
            source = Regex.Replace(source,@"\[url=(?<x>[^\]]*)\](?<y>[^\]]*)\[/url\]",@"<a href=$1 target=_blank>$2</a>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[url\](?<x>[^\]]*)\[/url\]",@"<a href=$1 target=_blank>$1</a>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[email=(?<x>[^\]]*)\](?<y>[^\]]*)\[/email\]",@"<a href=$1>$2</a>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[email\](?<x>[^\]]*)\[/email\]",@"<a href=$1>$1</a>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[flash](?<x>[^\]]*)\[/flash]",@"<OBJECT codeBase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=4,0,2,0 classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 width=500 height=400><PARAM NAME=movie VALUE=""$1""><PARAM NAME=quality VALUE=high><embed src=""$1"" quality=high pluginspage='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' width=500 height=400>$1</embed></OBJECT>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\",@"<IMG src=""$1"" border=0>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[color=(?<x>[^\]]*)\](?<y>[^\]]*)\[/color\]",@"<font color=$1>$2</font>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[face=(?<x>[^\]]*)\](?<y>[^\]]*)\[/face\]",@"<font face=$1>$2</font>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[size=1\](?<x>[^\]]*)\[/size\]",@"<font size=1>$1</font>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[size=2\](?<x>[^\]]*)\[/size\]",@"<font size=2>$1</font>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[size=3\](?<x>[^\]]*)\[/size\]",@"<font size=3>$1</font>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[size=4\](?<x>[^\]]*)\[/size\]",@"<font size=4>$1</font>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[size=5\](?<x>[^\]]*)\[/size\]",@"<font size=5>$1</font>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[size=6\](?<x>[^\]]*)\[/size\]",@"<font size=6>$1</font>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[align=(?<x>[^\]]*)\](?<y>[^\]]*)\[/align\]",@"<align=$1>$2</align>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[fly](?<x>[^\]]*)\[/fly]",@"<marquee width=90% behavior=alternate scrollamount=3>$1</marquee>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[move](?<x>[^\]]*)\[/move]",@"<marquee scrollamount=3>$1</marquee>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[glow=(?<x>[^\]]*),(?<y>[^\]]*),(?<z>[^\]]*)\](?<w>[^\]]*)\[/glow\]",@"<table width=$1 style='filter:glow(color=$2, strength=$3)'>$4</table>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[shadow=(?<x>[^\]]*),(?<y>[^\]]*),(?<z>[^\]]*)\](?<w>[^\]]*)\[/shadow\]",@"<table width=$1 style='filter:shadow(color=$2, strength=$3)'>$4</table>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[center\](?<x>[^\]]*)\[/center\]",@"<center>$1</center>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[b\](?<x>[^\]]*)\[/b\]",@"<b>$1</b>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[i\](?<x>[^\]]*)\[/i\]",@"<i>$1</i>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[u\](?<x>[^\]]*)\[/u\]",@"<u>$1</u>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[code\](?<x>[^\]]*)\[/code\]",@"<pre id=code><font size=1 face='Verdana, Arial' id=code>$1</font id=code></pre id=code>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[list\](?<x>[^\]]*)\[/list\]",@"<ul>$1</ul>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[list=1\](?<x>[^\]]*)\[/list\]",@"<ol type=1>$1</ol id=1>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[list=a\](?<x>[^\]]*)\[/list\]",@"<ol type=a>$1</ol id=a>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[\*\](?<x>[^\]]*)\[/\*\]",@"<li>$1</li>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[quote](?<x>.*)\[/quote]",@"<center>—— 以下是引用 ——<table border='1' width='80%' cellpadding='10' cellspacing='0' ><tr><td>$1</td></tr></table></center>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[QT=*([0-9]*),*([0-9]*)\](.[^\[]*)\[\/QT]",@"<embed src=$3 width=$1 height=$2 autoplay=true loop=false controller=true playeveryframe=false cache=false scale=TOFIT bgcolor=#000000 kioskmode=false targetcache=false pluginspage=http://www.apple.com/quicktime/>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[MP=*([0-9]*),*([0-9]*)\](.[^\[]*)\[\/MP]",@"<object align=middle classid=CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95 class=OBJECT id=MediaPlayer width=$1 height=$2 ><param name=ShowStatusBar value=-1><param name=Filename value=$3><embed type=application/x-oleobject codebase=http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701 flename=mp src=$3 width=$1 height=$2></embed></object>",RegexOptions.IgnoreCase);
            source = Regex.Replace(source,@"\[RM=*([0-9]*),*([0-9]*)\](.[^\[]*)\[\/RM]",@"<OBJECT classid=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA class=OBJECT id=RAOCX width=$1 height=$2><PARAM NAME=SRC VALUE=$3><PARAM NAME=CONSOLE VALUE=Clip1><PARAM NAME=CONTROLS VALUE=imagewindow><PARAM NAME=AUTOSTART VALUE=true></OBJECT><br><OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA height=32 id=video2 width=$1><PARAM NAME=SRC VALUE=$3><PARAM NAME=AUTOSTART VALUE=-1><PARAM NAME=CONTROLS VALUE=controlpanel><PARAM NAME=CONSOLE VALUE=Clip1></OBJECT>",RegexOptions.IgnoreCase);
            return(source);    
        }
            

        #region 整理(过滤)以英文逗号分割的字符串
        /// <summary>
        /// 整理(过滤)以英文逗号分割的字符串
        /// </summary>
        /// <param name="source">原字符串</param>
        /// <param name="str2">待清除的字符串，如空格</param>
        /// <returns></returns>
        #endregion
        public static string FilterStringArray(string source,string str2)
        {
            source = source.Replace(str2,"");
            if(source!="")
            {
                source = source.Replace(",,",",");

                if(source[0].ToString()==",")
                {
                    source = source.Substring(1,source.Length-1);
                }

                if(source[source.Length-1].ToString()==",")
                {
                    source = source.Substring(0,source.Length-1);
                }
            }
            return source;
        }

        
        #region 字符串组合

        #region 返回年月日时分秒组合的字符串
        /// <summary>
        /// 返回年月日时分秒组合的字符串,如：20050424143012 (2005年4月24日14点30分12秒)
        /// </summary>
        /// <param name="splitString">中间间隔的字符串，如2005\04\24\14\30\12。可以用来建立目录时使用</param>
        /// <returns></returns>
        #endregion
        public static string GetTimeString(string splitString)
        {
            DateTime now = DateTime.Now;

            StringBuilder sb = new StringBuilder();
            sb.Append(now.Year.ToString("0000"));
            sb.Append(splitString);
            sb.Append(now.Month.ToString("00"));
            sb.Append(splitString);
            sb.Append(now.Day.ToString("00"));
            sb.Append(splitString);
            sb.Append(now.Hour.ToString("00"));
            sb.Append(splitString);
            sb.Append(now.Minute.ToString("00"));
            sb.Append(splitString);
            sb.Append(now.Second.ToString("00"));
            
            return sb.ToString();
        }


        #region 返回年月日时分秒组合的字符串
        /// <summary>
        /// 返回年月日组合的字符串,如：20050424 (2005年4月24日)
        /// </summary>
        /// <param name="splitString">中间间隔的字符串，如2005\04\24 可以用来建立目录时使用</param>
        /// <returns></returns>
        #endregion
        public static string GetDateString(string splitString)
        {
            DateTime now = DateTime.Now;

            StringBuilder sb = new StringBuilder();
            sb.Append(now.Year.ToString("0000"));
            sb.Append(splitString);
            sb.Append(now.Month.ToString("00"));
            sb.Append(splitString);
            sb.Append(now.Day.ToString("00"));
            
            return sb.ToString();
        }


        #endregion

        #region 随机字符串,随机数

        private static string _LowerChar = "abcdefghijklmnopqrstuvwxyz";
        private static string _UpperChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string _NumberChar = "0123456789";

        #region 获取种子
        /// <summary>
        /// 使用RNGCryptoServiceProvider 做种，可以在一秒内产生的随机数重复率非常
        /// 的低，对于以往使用时间做种的方法是个升级
        /// </summary>
        /// <returns></returns>
        #endregion
        public static int GetNewSeed()
        {
            byte[] rndBytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(rndBytes);
            return BitConverter.ToInt32(rndBytes,0);
        }


        #region 取得指定范围内的数字随几数
        /// <summary>
        /// 取得指定范围内的随几数
        /// </summary>
        /// <param name="startNumber">下限数</param>
        /// <param name="endNumber">上限数</param>
        /// <returns>int</returns>
        #endregion
        public static int GetRandomNumber(int startNumber, int endNumber)
        {
            Random objRandom = new Random(GetNewSeed());
            int r = objRandom.Next(startNumber,endNumber);
            return r;
        }


        #region 获取指定 ASCII 范围内的随机字符串
        /// <summary>
        /// 获取指定 ASCII 范围内的随机字符串
        /// </summary>
        /// <param name="resultLength">结果字符串长度</param>
        /// <param name="startNumber"> 开始的ASCII值 如（33－125）中的 33</param>
        /// <param name="endNumber"> 结束的ASCII值 如（33－125）中的 125</param>
        /// <returns></returns>
        #endregion
        public static string GetRandomStringByASCII(int resultLength,int startNumber, int endNumber) 
        {
            System.Random objRandom = new System.Random(GetNewSeed());
            string result = null;
            for(int i=0; i<resultLength; i++) 
            {
                result += (char)objRandom.Next(startNumber, endNumber);
            }
            return result;
        }

        
        #region 从指定字符串中抽取指定长度的随机字符串
        /// <summary>
        /// 从指定字符串中抽取指定长度的随机字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="resultLength">待获取随机字符串长度</param>
        /// <returns></returns>
        #endregion
        public static string GetRandomString(string source,int resultLength) 
        {
            System.Random objRandom = new System.Random(GetNewSeed()); 
            string result = null;
            for(int i=0; i<resultLength; i++) 
            {
                result += source.Substring(objRandom.Next(0,source.Length-1),1);
            }
            return result;
        }

        
       #region 获取指定长度随机的数字字符串
        /// <summary>
        /// 获取指定长度随机的数字字符串
        /// </summary>
        /// <param name="resultLength">待获取随机字符串长度</param>
        /// <returns></returns>
        #endregion
        public static string GetRandomNumberString(int resultLength) 
        {
            return GetRandomString(_NumberChar,resultLength);
        }


        #region 获取指定长度随机的字母字符串（包含大小写字母）
        /// <summary>
        /// 获取指定长度随机的字母字符串（包含大小写字母）
        /// </summary>
        /// <param name="resultLength">待获取随机字符串长度</param>
        /// <returns></returns>
        #endregion
        public static string GetRandomLetterString(int resultLength) 
        {
            return GetRandomString(_LowerChar + _UpperChar, resultLength);
        }


        #region 获取指定长度随机的字母＋数字混和字符串（包含大小写字母）
        /// <summary>
        /// 获取指定长度随机的字母＋数字混和字符串（包含大小写字母）
        /// </summary>
        /// <param name="resultLength">待获取随机字符串长度</param>
        /// <returns></returns>
        #endregion
        public static string GetRandomMixString(int resultLength) 
        {
            return GetRandomString(_LowerChar + _UpperChar + _NumberChar, resultLength);
        }
  
        #endregion 

        #region 字符串验证

       #region 判断字符串是否为整型
        /// <summary>
        /// 判断字符串是否为整型
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static bool IsInteger(string source)
        {
            if(source ==null || source =="")
            {
                return false;
            }
            
            if(Regex.IsMatch(source,"^((\\+)\\d)?\\d*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #region Email 格式是否合法
        /// <summary>
        /// Email 格式是否合法
        /// </summary>
        /// <param name="strEmail"></param>
        #endregion
        public static bool IsEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail,@"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$");
        }


        #region 判断是否IP
        //// <summary>
        /// 判断是否IP
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static bool IsIP(string source)
        {
            return Regex.IsMatch(source,@"^(((25[0-5]|2[0-4][0-9]|19[0-1]|19[3-9]|18[0-9]|17[0-1]|17[3-9]|1[0-6][0-9]|1[1-9]|[2-9][0-9]|[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9]))|(192\.(25[0-5]|2[0-4][0-9]|16[0-7]|169|1[0-5][0-9]|1[7-9][0-9]|[1-9][0-9]|[0-9]))|(172\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|1[0-5]|3[2-9]|[4-9][0-9]|[0-9])))\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])$");
        }


        #region 检查字符串是否为A-Z、0-9及下划线以内的字符

        /// <summary>
        /// 检查字符串是否为A-Z、0-9及下划线以内的字符
        /// </summary>
        /// <param name="str">被检查的字符串</param>
        /// <returns>是否有特殊字符</returns>
        #endregion
        public static bool IsLetterOrNumber(string str)
        {
            bool b = System.Text.RegularExpressions.Regex.IsMatch(str,"[a-zA-Z0-9_]");
            return b;
        }
        

        #region 验输入字符串是否含有“/\<>:.?*|$]”特殊字符
        /// <summary>
        /// 验输入字符串是否含有“/\:.?*|$]”特殊字符
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static bool IsSpecialChar(string source)
        {
            Regex r = new Regex(@"[/\<>:.?*|$]");
            return r.IsMatch(source);            
        }
        

        #region 是否全为中文/日文/韩文字符
        /// <summary>
        /// 是否全为中文/日文/韩文字符
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns></returns>
        #endregion
        public static bool IsChineseChar(string source)
        {
            //中文/日文/韩文: [\u4E00-\u9FA5]
            //英文:[a-zA-Z]
            return Regex.IsMatch(source,@"^[\u4E00-\u9FA5]+$");
        }

        
        #region 是否包含双字节字符(允许有单字节字符)
        /// <summary>
        /// 是否包含双字节字符(允许有单字节字符)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static bool IsDoubleChar(string source)
        {
            return Regex.IsMatch(source,@"[^\x00-\xff]");
        }


        #region 是否为日期型字符串
        /// <summary>
        /// 是否为日期型字符串
        /// </summary>
        /// <param name="source">日期字符串(2005-6-30)</param>
        /// <returns></returns>
        #endregion
        public static bool IsDate(string source)
        {
            return Regex.IsMatch(source,@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
        }


        #region 是否为时间型字符串
        /// <summary>
        /// 是否为时间型字符串
        /// </summary>
        /// <param name="source">时间字符串(15:00:00)</param>
        /// <returns></returns>
        #endregion
        public static bool IsTime(string source)
        {
            return Regex.IsMatch(source,@"^((20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$");
        }


        #region 是否为日期+时间型字符串
        /// <summary>
        /// 是否为日期+时间型字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static bool IsDateTime(string source)
        {
            return Regex.IsMatch(source,@"^(((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$ ");
        }

        
        #region 是否为钱币型数据
        /// <summary>
        /// 是否为钱币型数据
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static bool IsMoney(string source)
        {
            return false;
        }

        #endregion 

        #region 字符串截取

        #region 获取字符串的实际长度(按单字节)
        /// <summary>
        /// 获取字符串的实际长度(按单字节)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static int GetRealLength(string source)
        {
            return System.Text.Encoding.Default.GetByteCount(source);
        }


        #region 取得固定长度的字符串(按单字节截取)
        /// <summary>
        /// 取得固定长度的字符串(按单字节截取)。
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="resultLength">截取长度</param>
        /// <returns></returns>
        #endregion
        public static string SubString(string source, int resultLength)
        {

            //判断字符串长度是否大于截断长度
            if(System.Text.Encoding.Default.GetByteCount(source) > resultLength)
            {
                //判断字串是否为空
                if(source == null)
                {
                    return "";
                }

                //初始化
                int i = 0, j = 0;

                //为汉字或全脚符号长度加2否则加1
                foreach (char newChar in source)
                {
                    if ((int)newChar > 127)
                    {
                        i += 2;
                    }
                    else
                    {
                        i ++;
                    }
                    if (i > resultLength)
                    {
                        source = source.Substring(0, j) ;
                        break;
                    }
                    j ++;
                }
            }
            return source;
        }
        

        #region 按长度分割字符串
        /// <summary>
        /// 按长度分割字符串，如短信
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        #endregion
        private ArrayList SplitStringByLength(string str,int len)
        {
            ArrayList arrBlock = new ArrayList();
            int intBlockCount = str.Length/len;
            if(str.Length%len!=0)
            {
                for(int i=0;i<=intBlockCount;i++)
                {
                    if((str.Length-i*len) > len)
                        arrBlock.Add(str.Substring(i*len,len));
                    else
                        arrBlock.Add(str.Substring(i*len,(str.Length%len)));
                }
            }
            else
            {
                for(int i=0;i<intBlockCount;i++)
                {
                    arrBlock.Add(str.Substring(i*len,len));
                }
            }   
            return arrBlock;
        }
        

        #endregion

        #region 字符串比较

        /// <summary>
        ///  获得某个字符串在另个字符串中出现的次数
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strSymbol">符号</param>
        /// <returns>返回值</returns>
        public static int GetStringIncludeCount(string strOriginal,string strSymbol)
        {
            
            int count=0;
            count = strOriginal.Length - strOriginal.Replace(strSymbol, String.Empty).Length;
            return count;
        }

        /**//// <summary>
        /// 获得某个字符串在另个字符串第一次出现时前面所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strSymbol">符号</param>
        /// <returns>返回值</returns>
        public static string GetFirstString(string strOriginal,string strSymbol)
        {
            int strPlace=strOriginal.IndexOf(strSymbol);
            if (strPlace!=-1)
            {
                strOriginal=strOriginal.Substring(0,strPlace);
            }
            return strOriginal;
        }

        /**//// <summary>
        /// 获得某个字符串在另个字符串最后一次出现时后面所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strSymbol">符号</param>
        /// <returns>返回值</returns>
        public static string GetLastString(string strOriginal,string strSymbol)
        {
            int strPlace=strOriginal.LastIndexOf(strSymbol)+strSymbol.Length;
            strOriginal=strOriginal.Substring(strPlace);
            return strOriginal;
        }

        /**//// <summary>
        /// 获得两个字符之间第一次出现时前面所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strFirst">最前哪个字符</param>
        /// <param name="strLast">最后哪个字符</param>
        /// <returns>返回值</returns>
        public static string GetTwoMiddleFirstStr(string strOriginal,string strFirst,string strLast)
        {
            strOriginal=GetFirstString(strOriginal,strLast);
            strOriginal=GetLastString(strOriginal,strFirst);
            return strOriginal;
        }

        /**//// <summary>
        ///  获得两个字符之间最后一次出现时的所有字符
        /// </summary>
        /// <param name="strOriginal">要处理的字符</param>
        /// <param name="strFirst">最前哪个字符</param>
        /// <param name="strLast">最后哪个字符</param>
        /// <returns>返回值</returns>
        public static string GetTwoMiddleLastStr(string strOriginal,string strFirst,string strLast)
        {
            strOriginal=GetLastString(strOriginal,strFirst);
            strOriginal=GetFirstString(strOriginal,strLast);
            return strOriginal;
        }

        /**//// <summary>
        /// 发帖过滤词（用“|”号分隔）Application["app_state_FilterWord"]
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="chkword">过滤词（用“|”号分隔）</param>
        public static bool CheckBadWords(string str,string chkword)
        {
            if( chkword!=null && chkword!="" )
            {
                string filter = chkword;
                string chk1="";
                string[] aryfilter = filter.Split('|');
                for(int i=0;i<aryfilter.Length;i++)
                {
                    chk1 = aryfilter[i].ToString();
                    if( str.IndexOf(chk1)>=0 )
                        return true;
                }
            }
            return false;
        }

        /**//// <summary>
        /// 发帖过滤字(需审核)（不同组间用“§”号分隔，同组内用“,”分隔）Application["app_state_Check_FilterWord"]
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="chkword">过滤字(需审核)（不同组间用“§”号分隔，同组内用“,”分隔）</param>
        public static bool CheckilterStr(string str,string chkword)
        {
            
            if( chkword!=null && chkword!="" )
            {
                string filter = chkword;
                string[] aryfilter = filter.Split('§');
                string[] aryfilter_lei;
                int lei_for=0,j;

                for(int i=0;i<aryfilter.Length;i++)
                {
                    lei_for=0;
                    aryfilter_lei = aryfilter[i].Split(',');
                    for(j=0;j<aryfilter_lei.Length;j++)
                    {
                        if( str.IndexOf(aryfilter_lei[j].ToString())>=0 )
                            lei_for += 1;
                    }
                    if( lei_for == aryfilter_lei.Length )
                        return true;
                }
            }
            return false;
        }


        #endregion 

        #region 字符集转换
        
        #region 将 GB2312 值转换为 UTF8 字符串(如：测试 -> 娴嬭瘯 )
        /**//// <summary>
        /// 将 GB2312 值转换为 UTF8 字符串(如：测试 -> 娴嬭瘯 )
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static string ConvertGBToUTF8(string source)
        {
            /**//*
            byte[] bytes;
            bytes = System.Text.Encoding.Default.GetBytes(source);
            System.Text.Decoder gbDecoder = System.Text.Encoding.GetEncoding("gb2312").GetDecoder();
            int charCount = gbDecoder.GetCharCount(bytes,0 , bytes.Length);
            Char[] chars = new Char[charCount];
            int charsDecodedCount = gbDecoder.GetChars(bytes,0,bytes.Length,chars,0);
            return new string(chars);
            */

            return Encoding.GetEncoding("GB2312").GetString(Encoding.UTF8.GetBytes(source));
        }
        

        #region 将 UTF8 值转换为 GB2312 字符串 (如：娴嬭瘯 -> 测试)
        /**//// <summary>
        /// 将 UTF8 值转换为 GB2312 字符串 (如：娴嬭瘯 -> 测试)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static string ConvertUTF8ToGB(string source) 
        {
            /**//*
            byte[] bytes;
            //模拟编码
            System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();
            bytes = utf8.GetBytes(source); 
            
            //开始解码
            System.Text.Decoder utf8Decoder = System.Text.Encoding.UTF8.GetDecoder();

            int charCount = utf8Decoder.GetCharCount(bytes, 0, bytes.Length);
            Char[] chars = new Char[charCount];
            int charsDecodedCount = utf8Decoder.GetChars(bytes, 0, bytes.Length, chars, 0);

            return new string(chars);
            */
            
            return Encoding.UTF8.GetString(Encoding.GetEncoding("GB2312").GetBytes(source));
        }


        #region 由16进制转为汉字字符串（如：B2E2 -> 测 ）
        /**//// <summary>
        /// 由16进制转为汉字字符串（如：B2E2 -> 测 ）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static string ConvertHexToString(string source)
        {
            byte[] oribyte = new byte[source.Length/2];
            for(int i=0;i<source.Length;i+=2)
            {
                string str = Convert.ToInt32(source.Substring(i,2),16).ToString();
                oribyte[i/2] = Convert.ToByte(source.Substring(i,2),16);
            }
            return System.Text.Encoding.Default.GetString(oribyte);
        }


        #region  字符串转为16进制字符串（如：测 -> B2E2 ）
        /**//// <summary>
        /// 字符串转为16进制字符串（如：测 -> B2E2 ）
        /// </summary>
        /// <param name="Word"></param>
        /// <returns></returns>
        #endregion
        public static string ConvertToHex(string Word)
        {
            int i=Word.Length;
            string temp;
            string end="";
            byte[] array = new byte[2];
            int i1 ,i2;
            for(int j=0;j<i;j++)
            {
                temp=Word.Substring(j,1);
                array = System.Text.Encoding.Default.GetBytes(temp);
                if(array.Length.ToString()=="1")
                {
                    i1=Convert.ToInt32(array[0]);
                    end+=Convert.ToString(i1,16);
                }
                else
                {
                    i1=Convert.ToInt32(array[0]);
                    i2=Convert.ToInt32(array[1]);
                    end+=Convert.ToString(i1,16);
                    end+=Convert.ToString(i2,16);
                }
            }
            return end.ToUpper();
        }


        #region 字符串转为unicode字符串（如：测试 -> &#27979;&#35797;）
        /**//// <summary>
        /// 字符串转为unicode字符串（如：测试 -> &#27979;&#35797;）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static string ConvertToUnicode(string source)
        {
            StringBuilder sa = new StringBuilder();//Unicode
            string s1;
            string s2;
            for(int i=0;i<source.Length;i++)
            { 
                byte[] bt = System.Text.Encoding.Unicode.GetBytes(source.Substring(i,1));
                if(bt.Length>1)//判断是否汉字
                {
                    s1=Convert.ToString((short)(bt[1] - '\0'),16);//转化为16进制字符串
                    s2=Convert.ToString((short)(bt[0] - '\0'),16);//转化为16进制字符串
                    s1=(s1.Length==1?"0":"")+s1;//不足位补0
                    s2=(s2.Length==1?"0":"")+s2;//不足位补0
                    sa.Append("&#"+Convert.ToInt32(s1+s2,16) +";");
                }
            }

            return sa.ToString();
        }

        
        #region 字符串转为UTF8字符串（如：测试 -> \u6d4b\u8bd5）
        /**//// <summary>
        /// 字符串转为UTF8字符串（如：测试 -> \u6d4b\u8bd5）
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static string ConvertToUTF8(string source)
        {
            StringBuilder sb = new StringBuilder();//UTF8
            string s1;
            string s2;
            for(int i=0;i<source.Length;i++)
            { 
                byte[] bt = System.Text.Encoding.Unicode.GetBytes(source.Substring(i,1));
                if(bt.Length>1)//判断是否汉字
                {
                    s1=Convert.ToString((short)(bt[1] - '\0'),16);//转化为16进制字符串
                    s2=Convert.ToString((short)(bt[0] - '\0'),16);//转化为16进制字符串
                    s1=(s1.Length==1?"0":"")+s1;//不足位补0
                    s2=(s2.Length==1?"0":"")+s2;//不足位补0
                    sb.Append("\\u"+s1+s2);
                }
            }

            return sb.ToString();
        }


        #region 转化为ASC码方法
        //转化为ASC码方法

        public string ConvertToAsc(string txt)
        {
            string newtxt="";
            foreach(char c in txt)
            {
                
                newtxt+=Convert.ToString((int)c);
            } 
            return newtxt;
        
        }
        #endregion

       #region BASE64

        /**//// <summary>
        /// 将字符串使用base64算法加密
        /// </summary>
        /// <param name="source">待加密的字符串</param>
        /// <returns>加码后的文本字符串</returns>
        public static string Base64_Encrypt(string source)
        {
            return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(source));
        }

        /**//// <summary>
        /// 从Base64编码的字符串中还原字符串，支持中文
        /// </summary>
        /// <param name="source">Base64加密后的字符串</param>
        /// <returns>还原后的文本字符串</returns>
        public static string Base64_Decrypt(string source)
        {
            return System.Text.Encoding.Default.GetString(Convert.FromBase64String(source));
        }
        #endregion

        #endregion

        #region 字符串格式化

        #region 将字符串反转
        /**//// <summary>
        /// 将字符串反转
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        #endregion
        public static string FormatReverse(string source)
        {
            char[] ca = source.ToCharArray();
            Array.Reverse( ca );
            source = new String( ca );
            return source;
        }


        /**//// <summary>
        /// 格式化为小数点两位的字符串(四舍五入)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string FormatFloat2(double source)
        {
            //double tmp=1223333.24215265652;
            return source.ToString("##,###.000");
        }

        
        /**//// <summary>
        /// 将数字字符串转成货币格式
        /// </summary>
        /// <returns></returns>
        public static string GetMoneyFormat()
        {
            /**//*
            string.Format("${0:###,###,###.##}元",decimalVar);
            --------------------------------------------------------------------------------
            找到system.string的format方法
            string str="99988"
            str=format(str,"##,####.00")
            str value is:99,988.00
            试一下行不行
            --------------------------------------------------------------------------------
            string strMoney="544.54";
            decimal decMoney=System.Convert.ToDecimal(strMoney);
            string money=decMoney.ToString("c");

            如果要转换成不同地区的符号，可以用：
            CultureInfo MyCulture =  new CultureInfo("zh-CN");
            String MyString = MyInt.ToString("C", MyCulture);

            注意:这里OrderTotal的格式只能是Decimal.

             */
            return "";
        }


        /**//// <summary>
        /// 格式化字符串 字符串1234567,想变成1,234,567
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetO1(string source)
        {
            //return source.ToString("N");
            //return    source.ToString("###,###");
            return "";
        }


        /**//// <summary>
        /// 十进制数字1转换为字符串0a，在前面补零
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string OctToHex(int source)
        {
            return source.ToString("X2");
        }


        /**//// <summary>
        /// 将一个十六进制表示的字符串转成int型？如"0A" = 10
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string HexToOct(string source)
        {
            return Convert.ToInt16(source,16).ToString();
        }


        #endregion

        #region 身份证验证

        #region 从18位身份证获取用户所在省份、生日、性别信息
        /**//// <summary>
        /// 从18位身份证获取用户所在省份、生日、性别信息
        /// </summary>
        /// <param name="cid">身份证字符串</param>
        /// <returns>如：福建,1978-06-30,男</returns>
        #endregion
        public static string GetCidInfo(string cid)
        {
            string[] aCity = new string[]{null,null,null,null,null,null,null,null,null,null,null,"北京","天津","河北","山西","内蒙古",null,null,null,null,null,"辽宁","吉林","黑龙江",null,null,null,null,null,null,null,"上海","江苏","浙江","安微","福建","江西","山东",null,null,null,"河南","湖北","湖南","广东","广西","海南",null,null,null,"重庆","四川","贵州","云南","西藏",null,null,null,null,null,null,"陕西","甘肃","青海","宁夏","新疆",null,null,null,null,null,"台湾",null,null,null,null,null,null,null,null,null,"香港","澳门",null,null,null,null,null,null,null,null,"国外"};
            double iSum=0;
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^\d{17}(\d|x)$");
            System.Text.RegularExpressions.Match mc = rg.Match(cid);
            if(!mc.Success)
            {
                return "";
            }   
            cid = cid.ToLower();
            cid = cid.Replace("x","a");
            if(aCity[int.Parse(cid.Substring(0,2))]==null)
            {
                return "非法地区";
            }
            try
            {
                DateTime.Parse(cid.Substring(6,4)+"-"+cid.Substring(10,2)+"-"+cid.Substring(12,2));
            }
            catch
            {
                return "非法生日";
            }
            for(int i=17;i>=0;i--)
            {    
                iSum +=(System.Math.Pow(2,i)%11)*int.Parse(cid[17-i].ToString(),System.Globalization.NumberStyles.HexNumber);

            }
            if(iSum%11!=1)
                return("非法证号");
   
            return(aCity[int.Parse(cid.Substring(0,2))]+","+cid.Substring(6,4)+"-"+cid.Substring(10,2)+"-"+cid.Substring(12,2)+","+(int.Parse(cid.Substring(16,1))%2==1?"男":"女"));
  
        }


        #region 十五位的身份证号转为十八位的
        /**//// <summary>
        /// 十五位的身份证号转为十八位的
        /// </summary>
        /// <param name="source">十五位的身份证号</param>
        /// <returns></returns>
        #endregion
        public static string Cid15To18(string source)
        {
            string[] arrInt = new string[17]{"7", "9", "10", "5", "8", "4", "2", "1", "6", "3", "7", "9", "10", "5", "8", "4", "2"};
            string[] arrCh = new string[11]{"1", "0", "X", "9", "8", "7", "6", "5", "4", "3", "2"}; 
 
            int nTemp = 0, i;
 
            if(source.Length==15)
            {
                source = source.Substring(0,6) + "19" + source.Substring(6,source.Length-6);
                for(i = 0; i < source.Length; i ++)
                {
                    nTemp += int.Parse(source.Substring(i, 1)) * int.Parse(arrInt[i]);
                }
                source += arrCh[nTemp % 11]; 

                return source;
            }
            else
            {
                return null;
            }
            
        }   
        #endregion

        #region 随机数
        public static string  GetRandNum( int randNumLength )
        {
            System.Random randNum = new System.Random( unchecked( ( int ) DateTime.Now.Ticks ) );
            StringBuilder sb = new StringBuilder( randNumLength );
            for ( int i = 0; i < randNumLength; i++ )
            {
                sb.Append( randNum.Next( 0, 9 ) );
            }
            return sb.ToString();
        }

        #endregion

        #region 全角半角转换
        //// <summary>
           /// 转全角的函数(SBC case)
           /// </summary>
           /// <param name="input">任意字符串</param>
           /// <returns>全角字符串</returns>
           ///<remarks>
           ///全角空格为12288，半角空格为32
           ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
           ///</remarks>        
           public static string ToSBC(string input)
           {
               //半角转全角：
               char[] c = input.ToCharArray();
               for (int i = 0; i < c.Length; i++)
               {
                   if (c[i] == 32)
                   {
                       c[i] = (char)12288;
                       continue;
                   }
                   if (c[i] < 127)
                       c[i] = (char)(c[i] + 65248);
               }
               return new string(c);
           }


           /**//// <summary>
           /// 转半角的函数(DBC case)
           /// </summary>
           /// <param name="input">任意字符串</param>
           /// <returns>半角字符串</returns>
           ///<remarks>
           ///全角空格为12288，半角空格为32
           ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
           ///</remarks>
           public static string ToDBC(string input)
           {
               char[] c = input.ToCharArray();
               for (int i = 0; i < c.Length; i++)
               {
                   if (c[i] == 12288)
                   {
                       c[i] = (char)32;
                       continue;
                   }
                   if (c[i] > 65280 && c[i] < 65375)
                       c[i] = (char)(c[i] - 65248);
               }
               return new string(c);
           }
        #endregion



       }
}
