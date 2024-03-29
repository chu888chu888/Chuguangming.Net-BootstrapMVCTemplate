
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Web;
using WebUtility.Helper.Base;
namespace WebUtility.Helper.Image
{
    public static class ImageOp
    {

        #region 文字水印
        /// <summary>
        /// 文字水印
        /// </summary>
        /// <param name="wtext">水印文字</param>
        /// <param name="source">原图片物理文件名</param>
        /// <param name="target">生成图片物理文件名</param>
        public static bool ImageWaterText(string wtext, string source, string target)
        {
            bool resFlag = false;
            System.Drawing.Image image = System.Drawing.Image.FromFile(source);
            Graphics graphics = Graphics.FromImage(image);
            try
            {
                graphics.DrawImage(image, 0, 0, image.Width, image.Height);
                Font font = new System.Drawing.Font("Verdana", 60);
                Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
                graphics.DrawString(wtext, font, brush, 35, 35);
                image.Save(target);
                resFlag = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                graphics.Dispose();
                image.Dispose();

            }
            return resFlag;
        }


        #endregion


        #region 图片水印

        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_syp">生成的带图片水印的图片路径</param>
        /// <param name="Path_sypf">水印图片路径</param>
        public static bool ImageWaterPic(string source, string target, string waterPicSource)
        {
            bool resFlag = false;
            System.Drawing.Image sourceimage = System.Drawing.Image.FromFile(source);
            Graphics sourcegraphics = Graphics.FromImage(sourceimage);
            System.Drawing.Image waterPicSourceImage = System.Drawing.Image.FromFile(waterPicSource);
            try
            {
                sourcegraphics.DrawImage(waterPicSourceImage, new System.Drawing.Rectangle(sourceimage.Width - waterPicSourceImage.Width, sourceimage.Height - waterPicSourceImage.Height, waterPicSourceImage.Width, waterPicSourceImage.Height), 0, 0, waterPicSourceImage.Width, waterPicSourceImage.Height, GraphicsUnit.Pixel);
                sourceimage.Save(target);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sourcegraphics.Dispose();
                sourceimage.Dispose();
                waterPicSourceImage.Dispose();
            }
            return resFlag;

        }

        #endregion


    }
}
