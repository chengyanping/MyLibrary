using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.IDAL;
using MyLibrary.Model.Domain;
using MyLibrary.Model.ViewModel;

namespace MyLibrary.SQLServerDAL
{
    public class Book:IBook
    {
        private EFDbContext db = new EFDbContext();

        public IList<T_Book> GetLatestBooks(int categoryId, int topCount = 10)
        {

            var data = db.Books
                .Where(b => b.Category == null || b.CategoryId == categoryId)
                .OrderBy(b => b.BookId)
                .Take(topCount);

            return data.ToList();
        } 
        
        // 根据条件进行查询
        public IList<T_Book> getBooks(string where, string type)
        {
            List<T_Book> list = new List<T_Book>();

            if (string.IsNullOrEmpty(where))
            {
                var data = db.Books;
                list = data.ToList();
            }
            else
            {
                if (type == "关键词")
                {
                    var data = db.Books.Where(b => b.BookName.Contains(where));
                    list = data.ToList();
                }
                if (type == "ISBN")
                {
                    var data = db.Books.Where(b => b.ISBN13 == where);
                    list = data.ToList();
                }
                if (type == "作者")
                {
                    var data = db.Books.Where(b => b.Author == where);
                    list = data.ToList();
                }
                if (type == "类别号")
                {
                    int id = Convert.ToInt32(where);
                    var data = db.Books.Where(b => b.CategoryId == id);
                    list = data.ToList();
                }

            }
            return list;
        }
        //根据出版日期查询最新出版的12本书
        public IList<T_Book> getBooks()
        {
            List<T_Book> list = new List<T_Book>();
            var data = from item in db.Books orderby item.BookRecord descending select item;
            //var data = db.Books.Where(m => m.BookRecord > bookRecord);
            list = data.Take(12).ToList();
            return list;
        }

        //热门书籍
        public IList<hotBooks> getHotBooks()
        {
            IList<hotBooks> list = new List<hotBooks>();
            // var data = from item in db.BorrowedRecords group item by item.BookId into g select new { a=g.Key,hotb=new hotBooks { num = g.Count() } };
            //根据借阅数量进行排序,得到阅读量在前6的书目编号 nums= g.Count(m =>m.BookId==g.Key)
            //var da = (from hot in data orderby hot.nums descending select hot ).Take(6);
            //foreach (var item in da)
            //{
            //    var da1 = from p in db.Books where p.BookId == item.Key select p;
            //    //  list.Add(da1);
            //}
            /*
            var data2 = db.BorrowedRecords
                .GroupBy(x => x.BookId)
                .OrderByDescending(x => x.Count(m => m.BookId == x.Key))
                .Take(6)
                .Select(g => new hotBooks { num = g.Count(), Book = g.Where(x => x.BookId == g.Key).FirstOrDefault().Book });

            list = data2.ToList();
            */
            return list;


        }

    }
}
