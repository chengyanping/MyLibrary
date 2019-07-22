using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model.ViewModel;

namespace MyLibrary.IDAL
{
    public interface ICategoryInfo
    {
        IList<CategorySummaryInfo> GetCategoryInfos();
        CategorySummaryInfo GetCategoryInfo(int id);
    }
}
