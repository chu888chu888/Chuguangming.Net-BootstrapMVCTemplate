using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
using System.Collections;
namespace WebUtility.Security
{
    public static class CodeHelper
    {
        /// <summary>
        /// 使用MD5加密
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            if (str == null)
            {
                return null;
            }
            else
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
            }

        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DESEncrypt(string str, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放到byte数组中 
            byte[] inputByteArray = Encoding.Default.GetBytes(str);
            //建立加密对象的密钥和偏移量  
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法  
            //使得输入密码必须输入英文文本  
            des.Key = ASCIIEncoding.ASCII.GetBytes(key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream  
            //(It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format  as  hex  
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DESDecrypt(string str, string key)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //Put  the  input  string  into  the  byte  array  //把pToDecrypt中的32位字符每两位以
            //16进制转换为十进制的数字（如：DE ＝ 222）
            //然后存放在inputByteArray数组里面
            byte[] inputByteArray = new byte[str.Length / 2];
            for (int x = 0; x < str.Length / 2; x++)
            {
                int i = (Convert.ToInt32(str.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //建立加密对象的密钥和偏移量，此值重要，不能修改  
            des.Key = ASCIIEncoding.ASCII.GetBytes(key);
            des.IV = ASCIIEncoding.ASCII.GetBytes(key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //Get  the  decrypted  data  back  from  the  memory  stream  
            //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  
            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.Default.GetString(ms.ToArray());

        }

        public static string CnToEn(string cn)
        {
            if (cn.Length == 0)
            {
                return "";
            }
            char[] key = new char[36] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string splitStr = "z";
            string temp = "";
            int i = 1;
            for (i = 0; i < cn.Length; i++)
            {
                temp = temp + splitStr + CnToEnSingle(cn[i]);
            }
            return temp;
        }

        private static string CnToEnSingle(char cn)
        {
            char[] key = new char[36] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            int temp = (short)cn;
            //HttpContext.Current.Response.Write(temp);
            if (temp < 0)
            {
                temp = 65536 + temp;
            }
            return TenToN(temp, (key.Length - 1));
        }

        public static string EnToCn(string en)
        {
            if (en.Length == 0)
            {
                return "";
            }
            char[] key = new char[36] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string[] arr;
            string returnValue = "";
            arr = en.Split('z');
            for (int i = 0; i < arr.Length; i++)
            {
                returnValue = returnValue + (char)NToTen(arr[i], (key.Length - 1));
            }
            return returnValue;
        }

        /// <summary>
        /// 将十进制转换为N进制
        /// </summary>
        /// <param name="data">十进制数</param>
        /// <param name="n">进制</param>
        /// <returns>N进制</returns>
        private static string TenToN(int data, int n)
        {
            char[] key = new char[36] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            int temp;
            string returnValue = "";
            Stack s = new Stack();
            temp = data;
            do
            {
                s.Push(temp % n);
                temp = temp / n;
            }
            while (temp > 0);
            IEnumerator myEnumerator = s.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                returnValue += key[int.Parse(myEnumerator.Current.ToString())].ToString();
            }
            return returnValue;
        }

        private static int NToTen(string data, int n)
        {
            char[] key = new char[36] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string temp;
            int k = 0;
            int returnValue = 0;
            Stack s = new Stack();
            temp = data;
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[j] == data[i])
                    {
                        s.Push(j);
                    }
                }
            }
            IEnumerator myEnumerator = s.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                returnValue += int.Parse((int.Parse(myEnumerator.Current.ToString()) * Math.Pow(n, k)).ToString());
                k++;
            }
            return returnValue;
        }

    }
}
