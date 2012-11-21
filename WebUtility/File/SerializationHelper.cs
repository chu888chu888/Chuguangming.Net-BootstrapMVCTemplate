using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace SNSSolution.Helper
{
    /// <summary>
    /// 序列帮助类
    /// </summary>
    public class SerializationHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public static void Serialize(object obj, SerializationInfo info, StreamingContext context)
        {
            MemberInfo[] members = FormatterServices.GetSerializableMembers(obj.GetType(), context);
            foreach (FieldInfo field in members)
            {
                info.AddValue(field.Name, field.GetValue(obj), field.FieldType);
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public static void Deserialize(object obj, SerializationInfo info, StreamingContext context)
        {
            MemberInfo[] members = FormatterServices.GetSerializableMembers(obj.GetType(), context);
            foreach (FieldInfo field in members)
            {
                field.SetValue(obj, info.GetValue(field.Name, field.FieldType));
            }
        }



        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="filename">文件路径</param>
        /// <returns></returns>
        public static object Load(Type type, string filename)
        {
            FileStream fs = null;
            try
            {
                // open the stream
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }


        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filename">文件路径</param>
        public static void Save(object obj, string filename)
        {
            FileStream fs = null;
            // serialize it
            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

        }


        /// <summary>
        /// 序列化一个对象到内存中，并且返回一个BASE64的字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            IFormatter formatter = new BinaryFormatter();
            string result = string.Empty;
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);

                byte[] byt = new byte[stream.Length];
                byt = stream.ToArray();
                //result = Encoding.UTF8.GetString(byt, 0, byt.Length);
                result = Convert.ToBase64String(byt);
                stream.Flush();
            }
            return result;
        }


        /// <summary>
        /// 反序列化一个BASE64的字符串到内存中
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static object DeserializeObject(string str)
        {
            IFormatter formatter = new BinaryFormatter();
            //byte[] byt = Encoding.UTF8.GetBytes(str);
            byte[] byt = Convert.FromBase64String(str);
            object obj = null;
            using (Stream stream = new MemoryStream(byt, 0, byt.Length))
            {
                obj = formatter.Deserialize(stream);
            }
            return obj;
        }

    }

}
