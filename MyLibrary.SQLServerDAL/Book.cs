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
    }
}
