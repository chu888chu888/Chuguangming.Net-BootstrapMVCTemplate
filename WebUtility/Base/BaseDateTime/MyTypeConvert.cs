using System;
using System.Collections.Generic;
using System.Text;

namespace WebUtility.Base.BaseDateTime
{
   public  class MyTypeConvert
    {

        /// <summary>
        /// 忽略错误
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal InDecimal(object obj)
        {
            try
            {
                return Convert.ToDecimal(obj);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 转为double, 0时返回 "" (返回string类型的)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToDoubleInStrNo0(object obj)
        {
            double tmp = ToDoubleIgnErr(obj);
            if (tmp == 0)
                return "";
            else
                return tmp.ToString();
        }

        /// <summary>
        /// 2位小数double(返回string类型的)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToDoubleDigit2Str(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            double tmp = Convert.ToDouble(obj);
            return tmp.ToString("f2");
        }

        /// <summary>
        /// 2位小数的double
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDoubleDigit2(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            double tmp = Convert.ToDouble(obj);
            return Convert.ToDouble(tmp.ToString("f2"));
        }

        /// <summary>
        /// 格式化double为指定位数的double
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digit"></param>
        public static void ToDoubleDigit(ref double number, int digit)
        {
            number = ToDoubleDigit(number, digit);
        }

        /// <summary>
        /// 格式化double为2位数的double
        /// </summary>
        /// <param name="number"></param>
        public static void ToDoubleDigit(ref double number)
        {
            ToDoubleDigit(ref number, 2);
        }

        /// <summary>
        /// 格式化为指定位数的double
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digit"></param>
        /// <returns></returns>
        public static double ToDoubleDigit(object obj, int digit)
        {
            if (obj == null)
            {
                return 0;
            }
            double tmp = Convert.ToDouble(obj);
            return Convert.ToDouble(tmp.ToString("f" + digit.ToString()));
        }

        /// <summary>
        /// 格式化为2位数的double
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDoubleDigit(object obj)
        {
            return ToDoubleDigit(obj, 2);
        }
        /// <summary>
        /// 转化为double,忽略错误
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ToDoubleIgnErr(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            double t = 0;
            if (double.TryParse(str, out t))
                return t;
            else
                return 0;
        }

        /// <summary>
        /// 转化为int,忽略错误
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt32IgnErr(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            int rtnValue = 0;
            return int.TryParse(str, out rtnValue) ? rtnValue : 0;
        }

        /// <summary>
        /// 转化为double,忽略错误
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ToDoubleIgnErr(object obj)
        {
            return obj == null ? 0 : ToDoubleIgnErr(obj.ToString());
        }

        /// <summary>
        /// 转化为金额数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToMoneyCHN(object obj)
        {
            return ToMoneyCHN(ToDoubleIgnErr(obj));
        }

        /// <summary>
        /// 转化为金额数据
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public static string ToMoneyCHN(double money)
        {
            return money.ToString("c");
        }

        /// <summary>
        /// yy-MM-dd HH:mm 格式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToDateTimeMinuteShort(object obj)
        {
            try
            {
                DateTime dtime = Convert.ToDateTime(obj);
                return dtime.ToString("yy-MM-dd HH:mm");
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// yy-MM-dd
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToDateTimeDayShort(object obj)
        {
            try
            {
                DateTime dtime = Convert.ToDateTime(obj);
                return dtime.ToString("yy-MM-dd");
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToDateTimeMinute(object obj)
        {
            try
            {
                DateTime dtime = Convert.ToDateTime(obj);
                return dtime.ToString("yyyy-MM-dd HH:mm");
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// yyyy-MM-dd 或自定义格式 ; 转化错误时返回""
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToDateTimeIgnErr(object obj)
        {
            return ToDateTimeIgnErr(obj, "yyyy-MM-dd");
        }

        /// <summary>
        /// yyyy-MM-dd 或自定义格式 ; 转化错误时返回""
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string ToDateTimeIgnErr(object obj, string format)
        {
            try
            {
                DateTime dtime = Convert.ToDateTime(obj);
                return dtime.ToString(format);
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToDateTimeDay(object obj)
        {
            try
            {
                DateTime dtime = Convert.ToDateTime(obj);
                return dtime.ToString("yyyy-MM-dd");
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToDateTimeDay(string str)
        {
            try
            {
                DateTime dtime = Convert.ToDateTime(str);
                return dtime.ToString("yyyy-MM-dd");
            }
            catch (Exception)
            {
                return "";
            }
        }



        /// <summary>
        /// 转化为数据库数据 (空时返回ystem.DBNull.Value)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object ToDataRowData(object obj)
        {
            if (IsNull(obj))
            {
                return System.DBNull.Value;
            }
            else
                return obj;
        }

        /// <summary>
        /// 转化为数据库数据 (空时或0时返回ystem.DBNull.Value)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object ToDrInDbNo0(object obj)
        {
            if (IsNull(obj))
            {
                return System.DBNull.Value;
            }
            else
            {
                try
                {
                    double t = Convert.ToDouble(obj);
                    if (t == 0)
                    {
                        return System.DBNull.Value;
                    }
                    else
                    {
                        return t;
                    }
                }
                catch (Exception)
                {
                    return System.DBNull.Value;
                }
            }
        }

        /// <summary>
        /// 转化为数据库数据 (空时返回ystem.DBNull.Value)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object ToDrInDBNull(object obj)
        {
            if (obj == null || obj.ToString() == "")
            {
                return System.DBNull.Value;
            }
            else
            {
                return obj;
            }
        }

        /// <summary>
        /// 检查是否为空（null 或是""）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(object obj)
        {
            if (obj == null)
            {
                return true;
            }

            string typeName = obj.GetType().Name;
            switch (typeName)
            {
                case "String[]":
                    string[] list = (string[])obj;
                    if (list.Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    string str = obj.ToString();
                    if (str == null || str == "")
                        return true;
                    else
                        return false;
            }
        }


    }
}
