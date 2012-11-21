using System;
using System.Text.RegularExpressions;

namespace WebUtility.Base.BaseDateTime
{
    /// <summary>
    /// TimeHelp ��ժҪ˵����
    /// </summary>
    public class TimeHelp
    {

        public static DateTime NullDateTime
        {
            get { return new DateTime(1900, 1, 1); }
        }

        /// <summary>
        /// ʱ������
        /// </summary>
        public enum DateTimeType
        {
            /// <summary>
            /// ��ʼʱ�� ��: 2000-10-10 00:00:00
            /// </summary>
            Start = 0,
            /// <summary>
            /// ����ʱ�� ��: 2000-10-10 23:59:59
            /// </summary>
            End = 1,
        }

        /// <summary>
        /// �õ� yyyy-MM-dd �������ַ�
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetDateStr(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        #region GetDateTime �õ�����
        /// <summary>
        /// �õ�����
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

        #region GetDateTime �õ�����
        /// <summary>
        /// �õ�����
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

        #region GetDateTimeByStrDateTime ͨ�����ں�ʱ���ַ����õ�DateTime
        /// <summary>
        /// ͨ�����ں�ʱ���ַ����õ�DateTime
        /// </summary>
        /// <param name="date">�����ַ���</param>
        /// <param name="time">ʱ���ַ���</param>
        /// <returns></returns>
        public static DateTime GetDateTimeByStrDateTime(string date, string time)
        {
            return System.Convert.ToDateTime(date + " " + time);
        }
        #endregion

        #region GetDateFormat(string strDate) �õ�yyyy-MM-dd���ڸ�ʽ������
        /// <summary>
        /// �õ�yyyy-MM-dd���ڸ�ʽ������
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public string GetDateFormat(string strDate)
        {
            strDate = strDate.Trim();

            Regex r1 = new Regex(@"^(?<year>[1-9][0-9]{0,3})/(?<month>[0-9]{1,2})/(?<day>[0-9]{1,2})$");
            Regex r2 = new Regex(@"^(?<year>[1-9][0-9]{0,3})-(?<month>[0-9]{1,2})-(?<day>[0-9]{1,2})$");
            Regex r3 = new Regex(@"^(?<year>[1-9][0-9]{0,3})��(?<month>[0-9]{1,2})��(?<day>[0-9]{1,2})��$");
            Regex r4 = new Regex(@"^(?<month>[0-9]{1,2})/(?<day>[0-9]{1,2})/(?<year>[1-9][0-9]{0,3})$");

            // ȡ�����ڵ��꣬�£���
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
            else if (Regex.IsMatch(strDate, @"^(?<year>[1-9][0-9]{0,3})��(?<month>[0-9]{1,2})��(?<day>[0-9]{1,2})��$"))
            {
                year = r3.Match(strDate).Result("${year}");
                month = r3.Match(strDate).Result("${month}");
                date = r3.Match(strDate).Result("${day}");
            }
            else
            {
                throw new Exception("���ڸ�ʽ����ȷ");
            }

            // ��������ڵ���ȷ��
            try
            {
                System.DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(date));
                return dt.ToString("yyyy-MM-dd");
            }
            catch
            {
                throw new Exception("���ڸ�ʽ����ȷ");
            }
        }
        #endregion
    }
}
