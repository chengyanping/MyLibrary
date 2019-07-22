using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model.Domain;
using MyLibrary.Model.ViewModel;
using MyLibrary.IDAL;

namespace MyLibrary.SQLServerDAL
{
    public class UserLog:IUserLog
    {
        private EFDbContext db = new EFDbContext();

        public void Add(T_UserLog log)
        {
            db.UserLogs.Add(log);
        }

        public PageSearchResult<T_UserLog> UserLogSearch(UserLogSearchModel search)
        {
            var data = db.UserLogs.OrderBy(x => x.ID).Where(x => 1 == 1);
            var pageResult = data.ToList();
            PageSearchResult<T_UserLog> pageViewResult = new PageSearchResult<T_UserLog>()
            {
                Items = pageResult,
                Page = search.Page,
                PageSize = search.PageSize,
                TotalCount = pageResult.Count
            };
            return pageViewResult;           
        }
    }
}
