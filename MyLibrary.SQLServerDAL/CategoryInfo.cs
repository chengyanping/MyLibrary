using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.IDAL;
using MyLibrary.Model.ViewModel;

namespace MyLibrary.SQLServerDAL
{
    public class CategoryInfo : ICategoryInfo
    {
      
        private EFDbContext db = new EFDbContext();
        public IList<Model.ViewModel.CategorySummaryInfo> GetCategoryInfos()
        {
            var data = from a in db.Categories                      
                       select new MyLibrary.Model.ViewModel.CategorySummaryInfo
                       {
                           CategoryId = a.ID,
                            CategoryName = a.Name,
                             Count= 100
                       };
            return data.ToList();
        }

        CategorySummaryInfo ICategoryInfo.GetCategoryInfo(int id)
        {
            return GetCategoryInfos().SingleOrDefault(x => x.CategoryId == id);
        }

       
    }
}
