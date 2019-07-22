using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model.Domain;
using MyLibrary.Model.ViewModel;

namespace MyLibrary.IDAL
{
    public interface IUserLog
    {

        void Add(T_UserLog log);
        PageSearchResult<T_UserLog> UserLogSearch(UserLogSearchModel search);
    }
}
