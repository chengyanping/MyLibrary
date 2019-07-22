using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model.Domain;
using MyLibrary.Model.ViewModel;

namespace MyLibrary.IDAL
{
    public interface IGetPwd
    {
        T_GetPwd GetPwdRecord(int userId);
        T_GetPwd GetPwdRecord(string guid);

        bool Add(T_GetPwd getPwd);

        bool Update(T_GetPwd getPwd);
    }
}
