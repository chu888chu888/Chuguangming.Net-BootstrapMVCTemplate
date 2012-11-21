using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace WebUtility.Base.ValidateHelper
{
    /// <summary>
    /// RegularHelper��һ����װ�˳��õ�������ʽ����
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
        /// ������֤�Ƿ�������
        /// </summary>
        /// <param name="MatchString">The match string.</param>
        /// <returns>
        /// 	<c>true</c> ��������ĵĻ�������true������Ϊfalse <c>false</c>.
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
        /// �Ƿ���˫�ֽ��ַ�(��������)
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
        /// �Ƿ��ǿ��ַ���
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
        /// �Ƿ���html����
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
        /// �Ƿ���Email
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
        /// �Ƿ���url
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
        /// ƥ��Ǹ������������� + 0��
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
        /// ƥ��������
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
        /// ƥ����������������� + 0��
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
        /// ƥ����26��Ӣ����ĸ��ɵ��ַ���
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
        /// ƥ�������ֺ�26��Ӣ����ĸ��ɵ��ַ��� 
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
        /// ����Ƿ���ID
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
        /// ����0��Decimal����
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
        /// �κ�Decimal����
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
        /// �ǲ���html
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
        /// �ǲ���GUID
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
        /// �ǲ���html��ע��
        /// </summary>
        /// <param name="PostStr"></param>
        /// <example>
        /// ����html�е�ע�� 
        ///    ���ʽ
        ///     <!\-\-.*?\-\->
        ///     
        ///    ����
        ///     ����html�е�ע��
        ///     
        ///    ƥ�������
        ///     <!-- <h1>this text has been removed</h1> -->
        ///     
        ///    ��ƥ�������
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
        /// ����Ƿ���MD5�ַ���
        /// </summary>
        /// <example>
        /// ƥ��MD5�����ַ��� 
        /// ���ʽ
        ///  ^(\d)(\d)*( )*(px|PX|Px|pX|pt|PT|Pt|pT|)$
        ///  
        /// ����
        ///  ^([a-z0-9]{32})$
        ///  
        /// ƥ�������
        ///  790d2cf6ada1937726c17f1ef41ab125
        ///  
        /// ��ƥ�������
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
        /// �Ƿ���ANSI SQL ����
        /// </summary>
        /// <example>
        /// ����
        ///  ƥ��ANSI SQL�����ڸ�ʽ��YYYY-mm-dd hh:mi:ss am/pm
        /// 
        /// ��������1901-2099�Ƿ������ꡣ
        ///  
        /// ƥ�������
        ///  2004-2-29
        /// 
        /// 2004-02-29 10:29:39 pm
        /// 
        /// 2004/12/31
        ///  
        /// ��ƥ�������
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
