using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model.Domain;
using MyLibrary.Model.ViewModel;

namespace MyLibrary.IDAL
{
    public interface IUser
    {
        IList<T_User> GetAllUsers();

        int AddUser(T_User user);

        T_User GetUserInfo(int userid);

        T_User GetUserInfo(string userName, string password);

        T_User GetUserInfoByUserName(string userName);

        T_User GetUserInfoByEmail(string email);

        void UpdateUserPwd(int uid, string password);

        PageSearchResult<T_User> UserSearch(UserSearchModel search);

        void UpdateUserInfo(T_User userinfo);

        int DeleteUser(int uid);

        int AddUserLog(T_UserLog log);

        PageSearchResult<T_UserLog> UserLogSearch(UserLogSearchModel search);
      
        int AddGetPwdRecord(T_GetPwd getpwd);
       
        T_GetPwd GetPwdRecord(int userid);
      

        T_GetPwd GetPwdRecord(string guid);


        void UpdateGetPwd(T_GetPwd item);
       
    }
}
