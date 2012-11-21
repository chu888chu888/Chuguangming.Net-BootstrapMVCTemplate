using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Data;

namespace WebUtility.Base.StringHelper
{
    public class ConvertHelper
    {
        #region 转换为字符型
        /// <summary>
        /// 转换为字符型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            if ((obj == DBNull.Value) || (obj == null))
            {
                return "";
            }
            else
            {
                return obj.ToString().Trim();
            }
        }
        #endregion

        #region 转换为GUID
        /// <summary>
        /// 转换为GUID
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Guid ToGuid(object obj)
        {
            string patten = @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\"
                    + @"-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$";
            string str = ConvertHelper.ToString(obj);
            if (Regex.IsMatch(str.Trim(), patten) == true)
            {
                return new Guid(str);
            }
            else
            {
                return Guid.Empty;
            }
        }
        #endregion

        #region 转换为整型数字
        /// <summary>
        /// 转换为整型数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(object obj)
        {
            return ToInt(obj, 0, NumberStyles.None);
        }

        /// <summary>
        /// 转换为整型数字
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="nDefault"></param>
        /// <returns></returns>
        public static int ToInt(object obj, int nDefault)
        {
            return ToInt(obj, nDefault, NumberStyles.None);
        }

        /// <summary>
        /// 转换为整型数字
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="nDefault"></param>
        /// <param name="numStyle"></param>
        /// <returns></returns>
        public static int ToInt(object obj, int nDefault, NumberStyles numStyle)
        {
            int result = 0;
            result = nDefault;
            if (obj == null || obj == DBNull.Value)
            {
                result = nDefault;
            }
            else
            {
                int.TryParse(obj.ToString(), numStyle, null, out result);
            }
            return result;
        }
        #endregion

        #region 转换成浮点数
        /// <summary>
        /// 转换成浮点数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj)
        {
            return ToDecimal(obj, 0);
        }

        /// <summary>
        /// 转换成浮点数
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="dDefault"></param>
        /// <param name="numStyle"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj, decimal dDefault)
        {
            decimal result = 0;
            result = dDefault;
            if (obj == null || obj == DBNull.Value)
            {
                result = dDefault;
            }
            else
            {
                if (decimal.TryParse(obj.ToString(), out result) == false)
                {
                    result = dDefault;
                }
            }
            return result;
        }
        #endregion

        #region 转换成日期类型
        /// <summary>
        /// 转换成日期类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj)
        {
            return ToDateTime(obj, new DateTime(1900, 1, 1));
        }

        /// <summary>
        /// 转换成日期类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="dtDefault"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj, DateTime dtDefault)
        {
            DateTime result = new DateTime(1900, 1, 1);
            result = dtDefault;
            if (obj == null || obj == DBNull.Value)
            {
                result = dtDefault;
            }
            else
            {
                if (DateTime.TryParse(obj.ToString(), out result) == false)
                {
                    result = dtDefault;
                }
            }
            return result;
        }
        #endregion

        #region GUID转换为对应的数字
        /// <summary>
        /// GUID转换为对应的数字
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static int GuidToInt(string guid)
        {
            int result = 0;
            Guid id = new Guid(ToGuid(guid).ToString());
            byte[] bytes = id.ToByteArray();
            result = Math.Abs(((int)bytes[0]) | ((int)bytes[1] << 8) | ((int)bytes[2] << 16) | ((int)bytes[3] << 24));
            return result;
        }
        #endregion

        #region DataTable转Xml
        /// <summary>
        /// DataTable转Xml
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static string DataTableToXml(DataTable dt)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                stream = new MemoryStream();
                //从stream装载到XmlTextReader
                writer = new XmlTextWriter(stream, Encoding.Unicode);
                //用WriteXml方法写入文件.
                dt.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);

                UnicodeEncoding utf = new UnicodeEncoding();
                return utf.GetString(arr).Trim();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }
        #endregion

        #region DataSet转Xml
        /// <summary>
        /// DataSet转Xml
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns></returns>
        public static string DataSetToXml(DataSet ds)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                stream = new MemoryStream();
                //从stream装载到XmlTextReader
                writer = new XmlTextWriter(stream, Encoding.Unicode);
                //用WriteXml方法写入文件.
                ds.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);

                UnicodeEncoding utf = new UnicodeEncoding();
                return utf.GetString(arr).Trim();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }
        #endregion

        #region Xml转DataSet
        /// <summary>
        /// Xml转DataSet
        /// </summary>
        /// <param name="xml">Xml</param>
        /// <returns></returns>
        public static DataSet XmlToDataSet(string xml)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            DataSet ds = new DataSet();
            try
            {
                stream = new StringReader(xml);
                //从stream装载到XmlTextReader
                reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                return ds;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }
        #endregion

        #region Xml转DataTable
        /// <summary>
        /// Xml转DataTable
        /// </summary>
        /// <param name="xml">Xml</param>
        /// <returns></returns>
        public static DataTable XmlToDataTable(string xml)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                stream = new StringReader(xml);
                reader = new XmlTextReader(stream);
                ds.ReadXml(reader);
                dt = ds.Tables[0];
                return dt;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }
        #endregion

        #region DataTable转数据库实体
        /// <summary>
        /// DataTable转数据库实体
        /// </summary>
        /// <typeparam name="T">数据库实体类</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static T DataTableToEntity<T>(DataTable dt) where T : new()
        {
            int i = 0;
            int j = 0;
            T t = new T();
            System.Reflection.PropertyInfo[] pi = t.GetType().GetProperties();
            for (i = 0; i < dt.Columns.Count; i++)
            {
                for (j = 0; j < pi.Length; j++)
                {
                    if (dt.Columns[i].ColumnName.ToLower() == pi[j].Name.ToLower())
                    {
                        if (pi[j].PropertyType == typeof(int))
                        {
                            pi[j].SetValue(t, ConvertHelper.ToInt(dt.Rows[0][i]), null);
                        }
                        else if (pi[j].PropertyType == typeof(System.Guid))
                        {
                            pi[j].SetValue(t, ConvertHelper.ToGuid(dt.Rows[0][i]), null);
                        }
                        else if (pi[j].PropertyType == typeof(System.DateTime))
                        {
                            pi[j].SetValue(t, ConvertHelper.ToDateTime(dt.Rows[0][i]), null);
                        }
                        else
                        {
                            pi[j].SetValue(t, ConvertHelper.ToString(dt.Rows[0][i]), null);
                        }
                    }
                }
            }
            return t;
        }
        #endregion
    }
}
