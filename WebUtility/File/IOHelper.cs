using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Web;
namespace SNSSolution.Helper
{
public class FileHelper
    {
        /**//// <summary>
        /// 构造函数
        /// </summary>
        private FileHelper()
        {
        }

        #region 上传文件

        /**//// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="inputFile">html上传控件</param>
        /// <param name="uploadDirectory">上传到服务器目录</param>
        /// <param name="limitSite">上传文件大小限制(单位：字节)</param>
        /// <param name="fileName">输出文件名</param>
        /// <returns>返回操作逻辑值</returns>
        public static bool UpFile(HtmlInputFile inputFile, string uploadDirectory, int limitSite,out string fileName)
        {
            string acc = inputFile.PostedFile.FileName;//文件及路径名
            string accessory = string.Empty; //记录文件名
            fileName = string.Empty; //输出文件名

            if(inputFile.PostedFile.ContentLength > limitSite)
            {                
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('上传文件限制最大为"+Convert.ToString(limitSite/1024)+"k');history.back(-1);</script>"); 
                System.Web.HttpContext.Current.Response.End();
                return false;
            }
            else
            {
                if(acc.Trim().Length > 0)
                {
                    
                    //将新文件名以GUID重命名                
                    accessory = System.Guid.NewGuid().ToString() +"."+ GetFileType(acc);

                    if(!System.IO.Directory.Exists(uploadDirectory))
                    {
                        System.IO.Directory.CreateDirectory(uploadDirectory);
                    }

                    string access= uploadDirectory + accessory;
            
                    try
                    {
                        inputFile.PostedFile.SaveAs(access);
                        fileName = accessory;
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /**//// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="inputFile">html上传控件</param>
        /// <param name="uploadDirectory">上传到服务器目录</param>
        /// <param name="fileName">输出文件名</param>
        /// <param name="fileType">文件类型</param>
        /// <returns>返回操作逻辑值</returns>
        public static bool SaveFiles(HtmlInputFile inputFile, string uploadDirectory,string fileName,ref string fileType)
        {
            string upFile = inputFile.PostedFile.FileName;//文件及路径名
            
            if(upFile.Trim().Length > 0)
            {
                if(!System.IO.Directory.Exists(uploadDirectory))
                {
                    System.IO.Directory.CreateDirectory(uploadDirectory);
                }

                fileType = System.IO.Path.GetExtension(upFile);
                fileName = uploadDirectory + "/" + fileName + fileType;        
                try
                {
                    inputFile.PostedFile.SaveAs(fileName);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('请选择文件');history.back(-1);</script>"); 
                System.Web.HttpContext.Current.Response.End();
                return false;
            }                
        }


        /**//// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="inputFile">html上传控件</param>
        /// <param name="uploadDirectory">上传到服务器目录</param>
        /// <param name="limitSite">上传文件大小限制(单位：字节)</param>
        /// <param name="fileName">输出文件名</param>
        /// <returns>返回操作逻辑值</returns>
        public static bool SaveAccessory(HtmlInputFile inputFile, string uploadDirectory, int limitSite,string fileName)
        {
            string acc = inputFile.PostedFile.FileName;//文件及路径名
            uploadDirectory = System.Web.HttpContext.Current.Server.MapPath("./") + uploadDirectory;

            if(inputFile.PostedFile.ContentLength > limitSite)
            {                
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('上传文件限制最大为"+Convert.ToString(limitSite/1024)+"k');history.back(-1);</script>"); 
                System.Web.HttpContext.Current.Response.End();
                return false;
            }
            else
            {
                if(acc.Trim().Length > 0)
                {
                    if(!System.IO.Directory.Exists(uploadDirectory))
                    {
                        System.IO.Directory.CreateDirectory(uploadDirectory);
                    }

                    fileName = uploadDirectory + fileName;
            
                    try
                    {
                        inputFile.PostedFile.SaveAs(fileName);
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
            }
            return false;
        }

        #endregion

        /// <summary>
        /// 修改 Web.Config 中 appSettings 节点内节点信息
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="nodeKey">节点值</param>
        /// <returns>返回操作逻辑值</returns>
        public static bool SetWebConfigValue(string nodeName, string nodeKey)
        {
            string filename = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath + "/web.config");
            XmlDocument  xmldoc = new XmlDocument();
            xmldoc.Load(filename);
            System.Xml.XmlNode node = xmldoc.SelectSingleNode("configuration//appSettings");
            System.Xml.XmlNodeList nl = node.ChildNodes;
            foreach(XmlNode el in nl)
            {
                try
                {
                    if(el.Attributes["key"].Value == nodeName)
                    {
                        el.Attributes["value"].Value = nodeKey;
                    }
                } 
                catch
                {
                }
            }
            try
            {
                xmldoc.Save(filename);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /**//// <summary>
        /// 从完整路径中提取文件名
        /// </summary>
        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }


        /**//// <summary>
        /// 新建文件
        /// </summary>
        public static void Create(string path)
        {
            try
            {
                // 如果以存在文件就删除
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                //创建文件
                using (FileStream fs = File.Create(path)) { }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /**//// <summary>
        /// 重命名文件
        /// </summary>
        public static bool ReName(string soucePath, string newPath)
        {
            try
            {
                File.Move(soucePath, newPath);
            }
            catch
            {
                return false;
            }

            return true;
        }


        /**//// <summary>
        /// 移动文件
        /// </summary>
        public static bool Move(string fromPath, string toPath)
        {
            return ReName(fromPath, toPath);
        }


        /**//// <summary>
        /// 删除文件
        /// </summary>
        public static bool Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch
            {
                return false;
            }

            return true;
        }


        /**//// <summary>
        /// 获取文件扩展名
        /// </summary>
        public static string GetFileType(string path)
        {
            string type = Path.GetExtension(path);
           /**//* if (string.IsNullOrEmpty(type))
            {
                return type;
            }
            */
            return type.Substring(1);
        }


        /**//// <summary>
        /// 返回不具有扩展名的指定路径字符串的文件名
        /// </summary>
        public static string GetFileNameWithoutExtension(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }
        
        /**//// <summary>
        /// 判断目标文件夹是否存在
        /// </summary>
        /// <param name="path">文件夹路径 绝对路径  如： e:\zykey</param>
        /// <returns></returns>
        public static bool ifdir(string path)
        {
            DirectoryInfo d=new DirectoryInfo(path);
            return d.Exists;
        }

        /**//// <summary>
        /// 返回文件是否存在
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否存在</returns>
        public static bool FileExists(string filename)
        {
            return System.IO.File.Exists(filename);
        }



        


        /**//// <summary>
        /// 以指定的ContentType输出指定文件文件
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="filename">输出的文件名</param>
        /// <param name="filetype">将文件输出时设置的ContentType</param>
        public static void ResponseFile(string filepath, string  filename, string filetype)
        {
            Stream iStream = null;

            // 缓冲区为10k
            byte[] buffer = new Byte[10000];

            // 文件长度
            int length;

            // 需要读的数据长度
            long dataToRead;

            try
            {
                // 打开文件
                iStream = new FileStream(filepath, FileMode.Open, FileAccess.Read,FileShare.Read);


                // 需要读的数据长度
                dataToRead = iStream.Length;

                HttpContext.Current.Response.ContentType = filetype;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename.Trim()).Replace("+", " "));

                while (dataToRead > 0)
                {
                    // 检查客户端是否还处于连接状态
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        length = iStream.Read(buffer, 0, 10000);
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                        HttpContext.Current.Response.Flush();
                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        // 如果不再连接则跳出死循环
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error : " + ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    // 关闭文件
                    iStream.Close();
                }
            }
            HttpContext.Current.Response.End();
        }

        /**//// <summary>
        /// 判断文件名是否为浏览器可以直接显示的图片文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>是否可以直接显示</returns>
        public static bool IsImgFilename(string filename)
        {
            filename = filename.Trim();
            if (filename.EndsWith(".") || filename.IndexOf(".") == -1)
            {
                return false;
            }
            string extname = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            return (extname == "jpg" || extname == "jpeg" || extname == "png" || extname == "bmp" || extname == "gif");
        }            
    }

}
