using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using autotune.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

namespace autotune.Models
{
    public class ProjectRepository
    {
        ProjectContext pc = new ProjectContext();
        public IEnumerable<Product> Products { get { return pc.Products; } }

        public Product DeleteProduct(int id)
        {
            Product productForDelete = pc.Products.Find(id);
            if (productForDelete != null)
            {
                DeleteImages(productForDelete);
                pc.Products.Remove(productForDelete);
                pc.SaveChanges();
            }
            return productForDelete;
        }

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                pc.Products.Add(product);
            }
            else
            {
                Product forSave = pc.Products.Find(product.Id);
                if (forSave != null)
                {
                    if (forSave.BigImage != product.BigImage)
                    {
                        DeleteImages(forSave);
                    }
                    forSave.Name = product.Name;
                    forSave.Description = product.Description;
                    forSave.BigImage = product.BigImage;
                    forSave.SmallImage = SaveSmallImage(product.Id);
                    forSave.Category = product.Category;
                }
            }
            pc.SaveChanges();
        }

        /*private static Bitmap Resize(Bitmap imgPhoto, Size objSize, ImageFormat enuType)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = objSize.Width;
            int destHeight = objSize.Height;

            Bitmap bmPhoto;
            if (enuType == ImageFormat.Png)
                bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format32bppArgb);
            else if (enuType == ImageFormat.Gif)
                bmPhoto = new Bitmap(destWidth, destHeight);
            else
                bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);



            //If you want to override the default 96dpi resolution do it here
            //bmPhoto.SetResolution(72, 72);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        private string SaveSmallImage(int id)
        {
            String strImageFile = HttpContext.Current.Server.MapPath(string.Format("~/Images/big_{0}.jpg", id));
            Bitmap objImage = new Bitmap(strImageFile);
            Size objNewSize = new Size(200, 200);
            Bitmap objNewImage = Resize(objImage, objNewSize, ImageFormat.Jpeg);
            objNewImage.Save(HttpContext.Current.Server.MapPath(string.Format("~/Images/small_{0}.jpg", id)), ImageFormat.Jpeg);
            objNewImage.Dispose();
            objImage.Dispose();
            return string.Format("small_{0}.jpg", id);
        }*/

        private string SaveSmallImage(int productId)
        {
            String bigImageLocation = HttpContext.Current.Server.MapPath(string.Format("~/Images/big_{0}.jpg", productId));
            Bitmap bigImage = new Bitmap(bigImageLocation);
            Size newSize = new Size(200, 150);
            Bitmap smallImage = new Bitmap(bigImage, newSize);
            smallImage.Save(HttpContext.Current.Server.MapPath(string.Format("~/Images/small_{0}.jpg", productId)), ImageFormat.Jpeg);
            smallImage.Dispose();
            bigImage.Dispose();
            return string.Format("small_{0}.jpg", productId);
        }

        private void DeleteImages(Product product)
        {
            string smallPath = HttpContext.Current.Server.MapPath(string.Format("~/Images/small_{0}.jpg", product.Id));
            string bigPath = HttpContext.Current.Server.MapPath(string.Format("~/Images/big_{0}.jpg", product.Id));
            if (System.IO.File.Exists(smallPath))
            {
                System.IO.File.Delete(smallPath);
            }
            if (System.IO.File.Exists(bigPath))
            {
                System.IO.File.Delete(bigPath);
            }
        }
    }
}