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
    public class GetPwd : IGetPwd
    {
        public bool Add(T_GetPwd getPwd)
        {
            throw new NotImplementedException();
        }

        public T_GetPwd GetPwdRecord(string guid)
        {
            throw new NotImplementedException();
        }

        public T_GetPwd GetPwdRecord(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Update(T_GetPwd getPwd)
        {
            throw new NotImplementedException();
        }
    }
}
