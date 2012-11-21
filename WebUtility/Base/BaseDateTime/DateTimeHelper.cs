﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WebUtility.Base.BaseDateTime
{
    public class DateTimeHelper
    {
        #region 返回友好时间显示

        #region 带时间
        public static string GetManReadable(string datetime)
        {
            try
            {
                return GetManReadable(Convert.ToDateTime(datetime));
            }
            catch
            {
                return datetime;
            }
        }
        public static string GetManReadable(object datetime)
        {
            try
            {
                return GetManReadable(Convert.ToDateTime(datetime));
            }
            catch
            {
                return datetime.ToString();
            }
        }
        public static string GetManReadable(DateTime datetime)
        {
            string time = datetime.ToShortTimeString();
            return GetShortManReadable(datetime) + " " + time;
        }
        #endregion

        #region 不带时间
        public static string GetShortManReadable(string datetime)
        {
            if (string.IsNullOrEmpty(datetime.Trim()))
                return string.Empty;
            try
            {
                return GetShortManReadable(Convert.ToDateTime(datetime));
            }
            catch
            {
                return datetime;
            }
        }
        public static string GetShortManReadable(object datetime)
        {
            if (datetime == null || datetime.ToString().Trim() == string.Empty)
                return string.Empty;
            try
            {
                return GetShortManReadable(Convert.ToDateTime(datetime));
            }
            catch
            {
                return datetime.ToString();
            }
        }
        public static string GetShortManReadable(DateTime datetime)
        {
            DateTime now = DateTime.Now;
            if (now.Year == datetime.Year)//以下的前提是两时间都为同一年
            {
                TimeSpan span = now.Date - datetime.Date;
                int days = span.Days;
                switch (days)
                {
                    case 1:
                        return "昨天";
                    case 0:
                        return "今天";
                    case -1:
                        return "明天";
                    default:
                        break;
                }

                if (days >= -14 || days <= 14)
                {
                    GregorianCalendar gc = new GregorianCalendar();
                    int dateWeekofYear = gc.GetWeekOfYear(datetime, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                    int nowWeekofYear = gc.GetWeekOfYear(now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                    string dateDayofWeek = gc.GetDayOfWeek(datetime).ToString();
                    int weeks = nowWeekofYear - dateWeekofYear;
                    switch (weeks)
                    {
                        case 1:
                            return string.Format("上周{0}", WhichDay(dateDayofWeek));
                        case 0:
                            return string.Format("本周{0}", WhichDay(dateDayofWeek));
                        case -1:
                            return string.Format("下周{0}", WhichDay(dateDayofWeek));
                        default:
                            break;
                    }
                }

                if (days >= -62 || days <= 62)
                {
                    int months = now.Month - datetime.Month;
                    int dayofMonth = datetime.Day;
                    switch (months)
                    {
                        case 1:
                            return string.Format("上月{0}号", dayofMonth);
                        case 0:
                            return string.Format("本月{0}号", dayofMonth);
                        case -1:
                            return string.Format("下月{0}号", dayofMonth);
                        default:
                            break;
                    }
                }

            }
            else//以下的前提是两时间不同年
            {

            }

            return datetime.ToShortDateString();
        }
        #endregion

        public static string WhichDay(string enWeek)
        {
            switch (enWeek.Trim())
            {
                case "Sunday":
                    return "日";
                case "Monday":
                    return "一";
                case "Tuesday":
                    return "二";
                case "Wednesday":
                    return "三";
                case "Thursday":
                    return "四";
                case "Friday":
                    return "五";
                case "Saturday":
                    return "六";
                default:
                    return enWeek;
            }
        }
        #endregion

        #region 生日提醒
        public static string GetBirthdayTip(DateTime birthday)
        {
            DateTime now = DateTime.Now;
            //TimeSpan span = DateTime.Now - birthday;
            int nowMonth = now.Month;
            int birtMonth = birthday.Month;
            if (nowMonth == 12 && birtMonth == 1)
                return string.Format("下月{0}号", birthday.Day);
            if (nowMonth == 1 && birtMonth == 12)
                return string.Format("上月{0}号", birthday.Day);
            int months = now.Month - birthday.Month;
            //int days = now.Day - birthday.Day;
            if (months == 1)
                return string.Format("上月{0}号", birthday.Day);
            else if (months == -1)
                return string.Format("下月{0}号", birthday.Day);
            else if (months == 0)
            {
                if (now.Day == birthday.Day)
                    return "今天";
                return string.Format("本月{0}号", birthday.Day);
            }
            else
                return birthday.ToShortDateString();
        }
        public static string GetBirthdayTip(string birthday)
        {
            try
            {
                return GetBirthdayTip(Convert.ToDateTime(birthday));
            }
            catch
            {
                return birthday;
            }
        }

        #endregion

        #region 其他日期相关
        //// <summary>
        /// 返回日期加短时间格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetDateShortTime(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd hh:mm");
        }
        public static string GetDateShortTime(object o1)
        {
            try
            {
                return GetDateShortTime(Convert.ToDateTime(o1));

            }
            catch
            {
                return o1.ToString();
            }
        }
        /// <summary>
        /// 返回短日期
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetShortDate(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }
        public static string GetShortDate(object o1)
        {
            try
            {
                return GetShortDate(Convert.ToDateTime(o1));

            }
            catch
            {
                return o1.ToString();
            }
        }
        /// <summary>
        /// 获取下个月是几月
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetPreviousMonth(DateTime date)
        {
            return date.AddMonths(-1).Month;
        }
        /// <summary>
        /// 获取当月是几月
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetThisMonth(DateTime date)
        {
            return date.Month;
        }
        /// <summary>
        /// 获取下个月是几月
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetNextMonth(DateTime date)
        {
            return date.AddMonths(1).Month;
        }
        
        /// <summary>
        /// 获取前或后几个月是几月
        /// </summary>
        /// <param name="i"></param>
        /// <param name="date"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static int GetMonth(int i, DateTime date, out int year)
        {
            DateTime time = date.AddMonths(i);
            year = time.Year;
            return time.Month;
        }
        public static string GetWeek()
        {
            return string.Empty;
        }

        #endregion

    }
}
