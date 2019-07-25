using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model.Domain;
using MyLibrary.Model.ViewModel;
using MyLibrary.IDAL;

namespace MyLibrary.BLL
{
    public class Book
    {

        private readonly ICategoryInfo cgDAL = MyLibrary.DALFactory.DataAccess.CreateCategoryInfo();
        private readonly IBook bookDAL = MyLibrary.DALFactory.DataAccess.CreateBook();

        public IList<CategorySummaryInfo> GetCategoryInfos()
        {
            var items = cgDAL.GetCategoryInfos();
            return items;
        }

    
        public IList<T_Book> GetCategoryBooks(int categoryId,int topCount=10)
        {
            var data = bookDAL.GetLatestBooks(categoryId, topCount);
            return data;
        }

        //根据条件查询
        public IList<T_Book> getBooks(string where, string type)
        {
            var data = bookDAL.getBooks(where, type);
            return data;
        }
        //根据出版日期查询最新出版的12本书
        public IList<T_Book> getBooks()
        {
            return bookDAL.getBooks();
        }

        //热门书籍
        public IList<hotBooks> getHotBooks()
        {
            return bookDAL.getHotBooks();
        }



    }
}
