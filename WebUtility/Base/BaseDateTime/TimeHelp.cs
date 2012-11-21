using System;
using System.Text.RegularExpressions;

namespace WebUtility.Base.BaseDateTime
{
    /// <summary>
    /// TimeHelp 的摘要说明。
    /// </summary>
    public class TimeHelp
    {

        public static DateTime NullDateTime
        {
            get { return new DateTime(1900, 1, 1); }
        }

        /// <summary>
        /// 时间类型
        /// </summary>
        public enum DateTimeType
        {
            /// <summary>
            /// 开始时间 如: 2000-10-10 00:00:00
            /// </summary>
            Start = 0,
            /// <summary>
            /// 结束时间 如: 2000-10-10 23:59:59
            /// </summary>
            End = 1,
        }

        /// <summary>
        /// 得到 yyyy-MM-dd 的日期字符
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetDateStr(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        #region GetDateTime 得到日期
        /// <summary>
        /// 得到日期
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateTimeType"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(DateTime datetime, DateTimeType dateTimeType)
        {
            if (dateTimeType == DateTimeType.Start)
                return GetDateTimeByStrDateTime(GetDateStr(datetime), "00:00:00");
            else
                return GetDateTimeByStrDateTime(GetDateStr(datetime), "23:59:59");
        }
        #endregion

        #region GetDateTime 得到日期
        /// <summary>
        /// 得到日期
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dateTimeType"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string date, DateTimeType dateTimeType)
        {
            if (dateTimeType == DateTimeType.Start)
                return GetDateTimeByStrDateTime(date, "00:00:00");
            else
                return GetDateTimeByStrDateTime(date, "23:59:59");
        }
        #endregion

        #region GetDateTimeByStrDateTime 通过日期和时间字符串得到DateTime
        /// <summary>
        /// 通过日期和时间字符串得到DateTime
        /// </summary>
        /// <param name="date">日期字符串</param>
        /// <param name="time">时间字符串</param>
        /// <returns></returns>
        public static DateTime GetDateTimeByStrDateTime(string date, string time)
        {
            return System.Convert.ToDateTime(date + " " + time);
        }
        #endregion

        #region GetDateFormat(string strDate) 得到yyyy-MM-dd日期格式的日期
        /// <summary>
        /// 得到yyyy-MM-dd日期格式的日期
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public string GetDateFormat(string strDate)
        {
            strDate = strDate.Trim();

            Regex r1 = new Regex(@"^(?<year>[1-9][0-9]{0,3})/(?<month>[0-9]{1,2})/(?<day>[0-9]{1,2})$");
            Regex r2 = new Regex(@"^(?<year>[1-9][0-9]{0,3})-(?<month>[0-9]{1,2})-(?<day>[0-9]{1,2})$");
            Regex r3 = new Regex(@"^(?<year>[1-9][0-9]{0,3})年(?<month>[0-9]{1,2})月(?<day>[0-9]{1,2})日$");
            Regex r4 = new Regex(@"^(?<month>[0-9]{1,2})/(?<day>[0-9]{1,2})/(?<year>[1-9][0-9]{0,3})$");

            // 取得日期的年，月，日
            string year, month, date;

            if (Regex.IsMatch(strDate, @"^(?<month>[0-9]{1,2})/(?<day>[0-9]{1,2})/(?<year>[1-9][0-9]{3})$"))
            {
                year = r4.Match(strDate).Result("${year}");
                month = r4.Match(strDate).Result("${month}");
                date = r4.Match(strDate).Result("${day}");
            }
            else if (Regex.IsMatch(strDate, @"^(?<year>[1-9][0-9]{0,3})/(?<month>[0-9]{1,2})/(?<day>[0-9]{1,2})$"))
            {
                year = r1.Match(strDate).Result("${year}");
                month = r1.Match(strDate).Result("${month}");
                date = r1.Match(strDate).Result("${day}");
            }
            else if (Regex.IsMatch(strDate, @"^(?<year>[1-9][0-9]{0,3})-(?<month>[0-9]{1,2})-(?<day>[0-9]{1,2})$"))
            {
                year = r2.Match(strDate).Result("${year}");
                month = r2.Match(strDate).Result("${month}");
                date = r2.Match(strDate).Result("${day}");
            }
            else if (Regex.IsMatch(strDate, @"^(?<year>[1-9][0-9]{0,3})年(?<month>[0-9]{1,2})月(?<day>[0-9]{1,2})日$"))
            {
                year = r3.Match(strDate).Result("${year}");
                month = r3.Match(strDate).Result("${month}");
                date = r3.Match(strDate).Result("${day}");
            }
            else
            {
                throw new Exception("日期格式不正确");
            }

            // 最后检查日期的正确性
            try
            {
                System.DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(date));
                return dt.ToString("yyyy-MM-dd");
            }
            catch
            {
                throw new Exception("日期格式不正确");
            }
        }
        #endregion
    }
}
