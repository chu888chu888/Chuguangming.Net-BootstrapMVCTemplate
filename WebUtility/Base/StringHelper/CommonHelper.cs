using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

namespace WebUtility.Base.StringHelper
{
    public class CommonHelper
    {
        #region 获取日期是否单日
        /// <summary>
        /// 获取日期是否单日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsOddDay(DateTime date)
        {
            TimeSpan ts;
            bool flag = false;
            ts = date - (new DateTime(1900, 1, 1));
            if ((Math.Abs(ts.Days) % 2) == 0)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
            return flag;
        }
        #endregion

        #region 将日期的星期转换为数字
        /// <summary>
        /// 将日期的星期转换为数字
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int DayOfWeekToNumber(DateTime date)
        {
            int ReturnValue = 0;
            if (date.DayOfWeek.ToString().Equals(DayOfWeek.Monday.ToString()))
            {
                ReturnValue = 1;
            }
            else if (date.DayOfWeek.ToString().Equals(DayOfWeek.Tuesday.ToString()))
            {
                ReturnValue = 2;
            }
            else if (date.DayOfWeek.ToString().Equals(DayOfWeek.Wednesday.ToString()))
            {
                ReturnValue = 3;
            }
            else if (date.DayOfWeek.ToString().Equals(DayOfWeek.Thursday.ToString()))
            {
                ReturnValue = 4;
            }
            else if (date.DayOfWeek.ToString().Equals(DayOfWeek.Friday.ToString()))
            {
                ReturnValue = 5;
            }
            else if (date.DayOfWeek.ToString().Equals(DayOfWeek.Saturday.ToString()))
            {
                ReturnValue = 6;
            }
            else if (date.DayOfWeek.ToString().Equals(DayOfWeek.Sunday.ToString()))
            {
                ReturnValue = 7;
            }
            return ReturnValue;
        }
        #endregion

        #region 获取中国对应的地区编号
        public static string GetZoneIdOfChina()
        {
            return "54e7f5f6-d956-4fe4-ac42-71533f092038";
        }
        #endregion

        #region Dictionary转QueryString
        /// <summary>
        /// Dictionary转QueryString
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string DictionaryToQueryString(Dictionary<object, object> dic)
        {
            string result = string.Empty;
            if (dic != null && dic.Count > 0)
            {
                foreach (KeyValuePair<object, object> kvp in dic)
                {
                    if (result.Length == 0)
                    {
                        result = result + kvp.Key.ToString().Trim() + "=" + kvp.Value.ToString();
                    }
                    else
                    {
                        result = result + "&" + ConvertHelper.ToString(kvp.Key).Trim() + "=" + ConvertHelper.ToString(kvp.Value).Trim(); ;
                    }
                }
            }
            return result;
        }
        #endregion

        #region 将时间转换为数字
        public static int ConvertTimeToNumber(string time)
        {
            int result = 0;
            if (time.Equals(""))
            {
                time = "00:00";
            }
            if (time.Split(':').Length != 2)
            {
                time = "00:00";
            }
            result = (ConvertHelper.ToInt(time.Split(':')[0]) * 60) + ConvertHelper.ToInt(time.Split(':')[1]);
            return result;
        }
        #endregion

        #region 获取远程xml
        public static XmlDocument GetRemoteXml(string url)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(url);
            return xml;
        }
        #endregion
    }
}
