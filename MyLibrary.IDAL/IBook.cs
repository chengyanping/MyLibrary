
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model.ViewModel;
using MyLibrary.Model.Domain;

namespace MyLibrary.IDAL
{
    public interface IBook
    {

        IList<T_Book> GetLatestBooks(int categoryId, int topCount = 10);

    }
}
