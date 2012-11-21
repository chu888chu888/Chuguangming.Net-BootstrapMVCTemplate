using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace WebUtility.Base.ValidateHelper
{
    /// <summary>
    /// RegularHelper是一个封装了常用的正规表达式的类
    /// </summary>
    public class RegularHelper
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RegularHelper"/> class.
        /// </summary>
        public RegularHelper()
        {

        }

        /// <summary>
        /// 用于验证是否是中文
        /// </summary>
        /// <param name="MatchString">The match string.</param>
        /// <returns>
        /// 	<c>true</c> 如果是中文的话返回是true，否则为false <c>false</c>.
        /// </returns>
        public Boolean IsMatchChinese(string MatchString)
        {
            String ChineseRegex = @"[\u4e00-\u9fa5]";
            if (Regex.IsMatch(MatchString, ChineseRegex))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 是否是双字节字符(包括汉字)
        /// </summary>
        /// <param name="MatchString">The match string.</param>
        /// <returns>
        /// 	<c>true</c> if [is match double string] [the specified match string]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean IsMatchDoubleString(string MatchString)
        {
            String RegexString = @"[^\x00-\xff]";
            if (Regex.IsMatch(MatchString, RegexString))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 是否是空字符串
        /// </summary>
        /// <param name="MatchString">The match string.</param>
        /// <returns>
        /// 	<c>true</c> if [is match null string] [the specified match string]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean IsMatchNullString(string MatchString)
        {
            String RegexString = @"\n[\s| ]*\r";
            if (Regex.IsMatch(MatchString, RegexString))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 是否是html代码
        /// </summary>
        /// <param name="MatchString">The match string.</param>
        /// <returns>
        /// 	<c>true</c> if [is match HTML string] [the specified match string]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean IsMatchHtmlString(string MatchString)
        {
            String RegexString = @"/<(.*)>.*<\/\1>|<(.*) \/>/";
            if (Regex.IsMatch(MatchString, RegexString))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 是否是Email
        /// </summary>
        /// <param name="MatchString">The match string.</param>
        /// <returns>
        /// 	<c>true</c> if [is match email string] [the specified match string]; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsMatchEmailString(string MatchString)
        {
            String RegexString = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (Regex.IsMatch(MatchString, RegexString))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 是否是url
        /// </summary>
        /// <param name="MatchString">The match string.</param>
        /// <returns>
        /// 	<c>true</c> if [is match URL string] [the specified match string]; otherwise, <c>false</c>.
        /// </returns>
        public Boolean IsMatchUrlString(string MatchString)
        {
            String RegexString = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            if (Regex.IsMatch(MatchString, RegexString))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 匹配非负整数（正整数 + 0）
        /// </summary>
        /// <param name="MatchString"></param>
        /// <returns></returns>
        public Boolean IsMatchPositiveSignString(string MatchString)
        {
            String RegexString = @"^\d+$";
            if (Regex.IsMatch(MatchString, RegexString))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 匹配正整数
        /// </summary>
        /// <param name="MatchString"></param>
        /// <returns></returns>
        public Boolean IsMatchPositiveSignString2(string MatchString)
        {
            String RegexString = @"^[0-9]*[1-9][0-9]*$";
            if (Regex.IsMatch(MatchString, RegexString))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 匹配非正整数（负整数 + 0）
        /// </summary>
        /// <param name="MatchString"></param>
        /// <returns></returns>
        public Boolean IsMatchPositiveSignString3(string MatchString)
        {
            String RegexString = @"^((-\d+)|(0+))$";
            if (Regex.IsMatch(MatchString, RegexString))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 匹配由26个英文字母组成的字符串
        /// </summary>
        /// <param name="MatchString"></param>
        /// <returns></returns>
        public Boolean IsMatch24EnglishString(string MatchString)
        {
            String RegexString = @"^[A-Za-z]+$";
            if (Regex.IsMatch(MatchString, RegexString))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 匹配由数字和26个英文字母组成的字符串 
        /// </summary>
        /// <param name="MatchString"></param>
        /// <returns></returns>
        public Boolean IsMatch24EnglishStringAndNumber(string MatchString)
        {
            String RegexString = @"^[A-Za-z0-9]+$";
            if (Regex.IsMatch(MatchString, RegexString))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 检查是否是ID
        /// </summary>
        /// <param name="PostStr"></param>
        /// <returns></returns>
        public  bool IsID(string PostStr)
        {
            string RegStr = @"^[0-9]*[1-9][0-9]*$";
            if (Regex.IsMatch(PostStr, RegStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsEmail2(string EmailString)
        {
            string RegStr = @"(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})";
            if (Regex.IsMatch(EmailString, RegStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 大于0的Decimal数字
        /// </summary>
        /// <param name="PostStr"></param>
        /// <returns></returns>
        public bool IsDecimal(string PostStr)
        {
            string RegStr = @"(^\d*\.?\d*[1-9]+\d*$)|(^[1-9]+\d*\.\d*$)";
            if (Regex.IsMatch(PostStr, RegStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 任何Decimal数字
        /// </summary>
        /// <param name="PostStr"></param>
        /// <returns></returns>
        public bool IsDecimal2(string PostStr)
        {
            string RegStr = @"^(\d|-)?(\d|,)*\.?\d*$";
            if (Regex.IsMatch(PostStr, RegStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是不是html
        /// </summary>
        /// <param name="PostStr"></param>
        /// <returns></returns>
        public bool IsHtml(string PostStr)
        {
            string RegStr = @"<[^>]+>";
            if (Regex.IsMatch(PostStr, RegStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是不是GUID
        /// </summary>
        /// <param name="PostStr"></param>
        /// <returns></returns>
        public bool IsGUID(string PostStr)
        {
            string RegStr = @"^[{|\(]?[0-9a-fA-F]{8}[-]?([0-9a-fA-F]{4}[-]?){3}[0-9a-fA-F]{12}[\)|}]?$";
            if (Regex.IsMatch(PostStr, RegStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是不是html的注释
        /// </summary>
        /// <param name="PostStr"></param>
        /// <example>
        /// 查找html中的注释 
        ///    表达式
        ///     <!\-\-.*?\-\->
        ///     
        ///    描述
        ///     查找html中的注释
        ///     
        ///    匹配的例子
        ///     <!-- <h1>this text has been removed</h1> -->
        ///     
        ///    不匹配的例子
        ///     <h1>this text has been removed</h1>
        /// 
        /// </example>
        /// <returns></returns>
        public bool IsHtmlRemark(string PostStr)
        {
            string RegStr = @"<!\-\-.*?\-\->";
            if (Regex.IsMatch(PostStr, RegStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 检查是否是MD5字符串
        /// </summary>
        /// <example>
        /// 匹配MD5哈西字符串 
        /// 表达式
        ///  ^(\d)(\d)*( )*(px|PX|Px|pX|pt|PT|Pt|pT|)$
        ///  
        /// 描述
        ///  ^([a-z0-9]{32})$
        ///  
        /// 匹配的例子
        ///  790d2cf6ada1937726c17f1ef41ab125
        ///  
        /// 不匹配的例子
        ///  790D2CF6ADA1937726C17F1EF41AB125
        ///  
        /// </example>
        /// <param name="PostStr"></param>
        /// <returns></returns>
        public bool IsMD5(string PostStr)
        {
            string RegStr = @"^(\d)(\d)*( )*(px|PX|Px|pX|pt|PT|Pt|pT|)$";
            if (Regex.IsMatch(PostStr, RegStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是否是ANSI SQL 日期
        /// </summary>
        /// <example>
        /// 描述
        ///  匹配ANSI SQL的日期格式：YYYY-mm-dd hh:mi:ss am/pm
        /// 
        /// 包括检查从1901-2099是否是闰年。
        ///  
        /// 匹配的例子
        ///  2004-2-29
        /// 
        /// 2004-02-29 10:29:39 pm
        /// 
        /// 2004/12/31
        ///  
        /// 不匹配的例子
        ///  04-2-29
        /// 
        /// 04-02-29 10:29:39 pm
        /// 
        /// 04/12/31
        /// </example>
        /// <param name="PostStr"></param>
        /// <returns></returns>
        public bool IsANSISQLDate(string PostStr)
        {
            string RegStr = @"^(\d)(\d)*( )*(px|PX|Px|pX|pt|PT|Pt|pT|)$";
            if (Regex.IsMatch(PostStr, RegStr))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
