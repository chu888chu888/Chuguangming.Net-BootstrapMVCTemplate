using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace SNSSolution.Helper
{
    public class ImageHelper
    {
        #region Imageˮӡ
        /// <summary>
        /// д��ͼ��ˮӡ
        /// </summary>
        /// <param name="str">ˮӡ�ַ���</param>
        /// <param name="filePath">ԭͼƬλ��</param>
        /// <param name="savePath">ˮӡ������λ��</param>
        /// <returns></returns>
        public static string CreateBackImage(System.Web.UI.Page pageCurrent, string str, string filePath, string savePath, int x, int y)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(pageCurrent.MapPath(filePath));
            //����ͼƬ
            Graphics graphics = Graphics.FromImage(img);
            //ָ��Ҫ���Ƶ����
            graphics.DrawImage(img, 0, 0, img.Width, img.Height);
            //�����ֶκͻ���
            Font font = new Font("����", 16);
            Brush brush = new SolidBrush(Color.Yellow);
            graphics.DrawString(str, font, brush, x, y);
            //���沢���ͼƬ
            img.Save(pageCurrent.MapPath(savePath), System.Drawing.Imaging.ImageFormat.Jpeg);
            return savePath;

        }
        #endregion
        #region Image�Զ���С
        /// <summary>
        /// ��СͼƬ��ָ���Ĵ�С
        /// </summary>
        /// <param name="strOldPic">
        /// ԭͼƬ��λ��
        /// </param>
        /// <param name="strNewPic">
        /// ��С���ͼƬλ��
        /// </param>
        /// <param name="intWidth">
        /// ���
        /// </param>
        /// <param name="intHeight">
        /// �߶�
        /// </param>
        public static void SmallPic(string strOldPic, string strNewPic, int intWidth, int intHeight)
        {

            System.Drawing.Bitmap objPic, objNewPic;
            try
            {
                objPic = new System.Drawing.Bitmap(strOldPic);
                objNewPic = new System.Drawing.Bitmap(objPic, intWidth, intHeight);
                objNewPic.Save(strNewPic);
                objPic.Dispose();
                objNewPic.Dispose();

            }
            catch (Exception exp) { throw exp; }
            finally
            {
                objPic = null;
                objNewPic = null;
            }
        }

        public void SmallPic(string strOldPic, string strNewPic, int intWidth)
        {

            System.Drawing.Bitmap objPic, objNewPic;
            try
            {
                objPic = new System.Drawing.Bitmap(strOldPic);
                int intHeight = Convert.ToInt32(((intWidth * 1.0) / (objPic.Width * 1.0)) * objPic.Height);
                objNewPic = new System.Drawing.Bitmap(objPic, intWidth, intHeight);
                objNewPic.Save(strNewPic, objPic.RawFormat);

            }
            catch (Exception exp) { throw exp; }
            finally
            {
                objPic = null;
                objNewPic = null;
            }
        }
        private static void SmallPic(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            switch (mode)
            {
                case "HW":
                    break;
                case "W":
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H":
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut":
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);
            try
            {
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        //public void SmallPic(string strOldPic, string strNewPic, int intHeight)
        //{

        //    System.Drawing.Bitmap objPic, objNewPic;
        //    try
        //    {
        //        objPic = new System.Drawing.Bitmap(strOldPic);
        //        int intWidth = Convert.ToInt32(((intHeight * 1.0) / objPic.Height) * objPic.Width);
        //        objNewPic = new System.Drawing.Bitmap(objPic, intWidth, intHeight);
        //        objNewPic.Save(strNewPic, objPic.RawFormat);

        //    }
        //    catch (Exception exp) { throw exp; }
        //    finally
        //    {
        //        objPic = null;
        //        objNewPic = null;
        //    }
        //}
        #endregion
        #region ����ͼƬ��֤��
        /// <summary>
        /// ����ͼƬ��֤��
        /// </summary>
        /// <param name="ImageSavePath">
        /// ͼƬ�����λ��
        /// </param>
        /// <returns></returns>
        public string randomNumber(string ImageSavePath)
        {
            Bitmap newBitmap = new Bitmap(36, 20, PixelFormat.Format32bppArgb);
            //�������洴����λͼ���󴴽���ͼ��
            Graphics g = Graphics.FromImage(newBitmap);
            //��ָ������ɫ��������
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, 36, 20));
            //�����������
            Font textFont = new Font("Times New Roman", 10);
            //����RectangleF�ṹָ��һ������
            RectangleF rectangle = new RectangleF(0, 0, 36, 20);
            //�������������
            Random rd = new Random();
            //ȡ�������
            int valationNo = 1000 + rd.Next(8999);
            //ʹ��ָ������ɫ�������RectangleF�ṹָ���ľ�������
            g.FillRectangle(new SolidBrush(Color.DarkTurquoise), rectangle);
            //���������ľ�������������������ɵ������
            g.DrawString(valationNo.ToString(), textFont, new SolidBrush(Color.Blue), rectangle);
            //�Ѵ�����λͼ���浽ָ����·��
            newBitmap.Save(HttpContext.Current.Server.MapPath(ImageSavePath), ImageFormat.Gif);
            return valationNo.ToString();

        }
        #endregion

    }
}
