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
     

    

    }
}
