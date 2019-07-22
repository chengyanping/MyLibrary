using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model.Domain;
using MyLibrary.IDAL;
using MyLibrary.Model.ViewModel;

namespace MyLibrary.BLL
{
    public class User
    {
        private readonly IUser userDAL = MyLibrary.DALFactory.DataAccess.CreateUser();
        private readonly IUserLog userLogDAL = MyLibrary.DALFactory.DataAccess.CreateUserLog();
        private readonly IGetPwd getPwdDAL = MyLibrary.DALFactory.DataAccess.CreateGetPwd();

        public int AddUser(T_User user)
        {
            var userinfo =userDAL.GetUserInfoByUserName(user.UserName);
            if (userinfo != null)
            {
                return 0;
            }
            int userId = userDAL.AddUser(user);
            return userId;
        }


        public T_User GetUserInfo(string userName, string password)
        {
            var userinfo = userDAL.GetUserInfo(userName, password);
            return userinfo;
        }

        public T_User GetUserInfo(int userid)
        {
            var userinfo = userDAL.GetUserInfo(userid);
            return userinfo;
        }

        public T_User GetUserInfoByUserName(string userName)
        {
            var userinfo = userDAL.GetUserInfoByUserName(userName);
            return userinfo;
        }

        public T_User GetUserInfoByEmail(string email)
        {
            var userinfo = userDAL.GetUserInfoByEmail(email);
            return userinfo;
        }

        public void UpdateUserPwd(int uid, string password)
        {
            var user = GetUserInfo(uid);
            user.Password = password;
            userDAL.UpdateUserInfo(user);
        }

        public PageSearchResult<T_User> UserSearch(UserSearchModel search)
        {
            var pageViewResult = userDAL.UserSearch(search);
            return pageViewResult;
        }

        public void UpdateUserInfo(T_User userinfo)
        {
            userDAL.UpdateUserInfo(userinfo);
        }
   
        public bool DeleteUser(int uid)
        {
            return userDAL.DeleteUser(uid)>0;
        }

        public void AddUserLog(T_UserLog log)
        {
            userLogDAL.Add(log);
        }

        public PageSearchResult<T_UserLog> UserLogSearch(UserLogSearchModel search)
        {
            var pageViewResult = userLogDAL.UserLogSearch(search);
            return pageViewResult;
        }
       
        public bool AddGetPwdRecord(T_GetPwd getpwd)
        {
            return getPwdDAL.Add(getpwd);
        }

        public T_GetPwd GetPwdRecord(string guid)
        {
            return getPwdDAL.GetPwdRecord(guid);
        }

        public T_GetPwd GetPwdRecord(int userid)
        {
            return getPwdDAL.GetPwdRecord(userid);
        }
        public bool UpdateGetPwd(T_GetPwd item)
        {
            return getPwdDAL.Update(item);
        }


    }
}

