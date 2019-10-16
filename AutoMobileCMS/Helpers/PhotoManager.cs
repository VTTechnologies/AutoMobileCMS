using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace AutoMobileCMS.Helpers
{
    public static class PhotoManager
    {
        public static byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            if (image != null)
            {
                BinaryReader reader = new BinaryReader(image.InputStream);

                imageBytes = reader.ReadBytes((int)image.ContentLength);
            }
            return imageBytes;

        }
        public static string resizephoto(HttpPostedFileBase hp,int modelid,string type)
        {
            int Width = 370;
            int Height = 280;
            string myfile = "";
            var fileName = "";
            if (hp.ContentLength>0)
            {
                WebImage img = new WebImage(hp.InputStream);
                var allowedExtensions = new[] { ".png", ".jpg", "jpeg" };
                fileName = Path.GetFileName(hp.FileName); //getting only file name(ex-ganesh.jpg)  
                var ext = Path.GetExtension(hp.FileName); //getting the extension(ex-.jpg)  
                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                myfile = name + modelid.ToString() + ext; //appending the name with id  
                var path = "";
                if (type == "new")
                {
                    path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/ModelsImages"), myfile);
                }
                if (type == "sold")
                {
                    path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/SoldImages"), myfile);
                }

                //img.Save(path);
                img.Save(path);
                Image sourceimg = Image.FromFile(path);
                int swidth = sourceimg.Width;
                int sheight = sourceimg.Height;


                int sourceX = 0;
                int sourceY = 0;
                int destX = 0;
                int destY = 0;


                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;

                nPercentW = ((float)Width / (float)swidth);
                nPercentH = ((float)Height / (float)sheight);

                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = System.Convert.ToInt16((Width - (swidth * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = System.Convert.ToInt16((Height - (sheight * nPercent)) / 2);
                }
                int destWidth = (int)(swidth * nPercent);
                int destHeight = (int)(sheight * nPercent);
                Bitmap bmPhoto = new Bitmap(Width, Height,
                          PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(sourceimg.HorizontalResolution, sourceimg.VerticalResolution);
                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.Clear(Color.Red);
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.DrawImage(sourceimg, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX, sourceY, swidth, sheight), GraphicsUnit.Pixel);
                myfile = name + "New" + modelid.ToString() + ext;
                var path1 = "";
                if (type == "new")
                {
                    path1 = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/ModelsImages"), myfile);
                }
                if (type == "sold")
                {
                    path1 = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/SoldImages"), myfile);
                }

                bmPhoto.Save(path1);
                grPhoto.Dispose();
                bmPhoto.Dispose();
                sourceimg.Dispose();
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
               return myfile;
        }



        public static string savePhoto(HttpPostedFileBase hp, string flag)
        {
            if (hp != null)
            {
                var allowedExtensions = new[] { ".png", ".jpg", "jpeg" };
                var fileName = Path.GetFileName(hp.FileName); //getting only file name(ex-ganesh.jpg)  
                var ext = Path.GetExtension(hp.FileName); //getting the extension(ex-.jpg)  

                if (allowedExtensions.Contains(ext.ToLower())) //check what type of extension  
                {
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    string myfile = name  + ext; //appending the name with id  
                    var path = "";
                    if (flag=="new")
                    {
                        path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/ModelsImages"), myfile);
                    }
                    if (flag == "sold")
                    {
                        path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/SoldImages"), myfile);
                    }
                    
                    hp.SaveAs(path);
                    return myfile;
                }
            }
            else
            {
                return "empty";
            }
            return "fail";
        }
    }
}