using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyLibrary.BLL;
using MyLibrary.Model.Domain;
using MyLibrary.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MyLibrary.Web.Controllers
{
    public class BookApiController : ApiController
    {
        BLL.Book bookBLL = new BLL.Book();    



        public IEnumerable<T_Book> GetAllProducts()
        {
            List<T_Book> data = bookBLL.GetCategoryBooks(2, 10).ToList();

            //缩放图片
            
            data.ForEach(x =>
            {
                /*
                string path = "~/Images/WebImage/" + x.BookCover;

                string outPath = "~/Images/Weixin/" + Path.GetFileNameWithoutExtension(x.BookCover) + "_small" + Path.GetExtension(x.BookCover);
                path = System.Web.HttpContext.Current.Server.MapPath(path);
                path = "G:\\MyLibrary\\Code\\MyLibrary\\MyLibrary.Web\\Images\\WebImage\\1.jpg";

                outPath = System.Web.HttpContext.Current.Server.MapPath(outPath);
                outPath = "G:\\MyLibrary\\Code\\MyLibrary\\MyLibrary.Web\\Images\\Weixin\\1_small.jpg";

                Image image = Image.FromFile(path);//这是你图片文件的
                MemoryStream stream = new MemoryStream();

                image.Save(stream, ImageFormat.Bmp); //把图片保存到流中。

                image.Dispose();

                ImageTool.ZoomAuto(stream,outPath, 175, 175, "", "");


                x.BookCover = outPath;
                */
              


            });
            

            return data;



        }

        public IHttpActionResult GetProduct(int id)
        {
            IList<T_Book> contacts = bookBLL.GetCategoryBooks(2, 10);


            T_Book product = contacts.FirstOrDefault((p) => p.BookId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}