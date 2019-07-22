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
    public class User : IUser
    {
        private EFDbContext db = new EFDbContext();

        public int AddGetPwdRecord(T_GetPwd getpwd)
        {
            db.GetPwds.Add(getpwd);
            return db.SaveChanges();
        }

        public int AddUser(T_User user)
        {
            db.Users.Add(user);
            return db.SaveChanges();
        }

        public int AddUserLog(T_UserLog log)
        {

            db.UserLogs.Add(log);
            return db.SaveChanges();
        }

        public int DeleteUser(int uid)
        {
            var data = db.Users.Find(uid);
            db.Users.Remove(data);
            return db.SaveChanges();
        }

        public IList<T_User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public T_GetPwd GetPwdRecord(string guid)
        {
            return db.GetPwds.Where(x => x.Guid == guid).FirstOrDefault();
        }

        public T_GetPwd GetPwdRecord(int userid)
        {

            return db.GetPwds.Find(userid);
        }

        public T_User GetUserInfo(int userid)
        {
            return db.Users.Find(userid);
        }

        public T_User GetUserInfo(string userName, string password)
        {
            return db.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
        }

        public T_User GetUserInfoByEmail(string email)
        {
            return db.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public T_User GetUserInfoByUserName(string userName)
        {
            return db.Users.Where(x => x.UserName == userName).FirstOrDefault();
        }

        public void UpdateGetPwd(T_GetPwd item)
        {

            var data = db.GetPwds.Find(item.ID);
            data = item;
            db.SaveChanges();
        }

        public void UpdateUserInfo(T_User userinfo)
        {
            var data = db.Users.Find(userinfo.ID);
            data = userinfo;
            db.SaveChanges();
        }

        public void UpdateUserPwd(int uid, string password)
        {

            var data = db.Users.Find(uid);
            data.Password = password;
            db.SaveChanges();
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

        public PageSearchResult<T_User> UserSearch(UserSearchModel search)
        {
            var data = db.Users.OrderBy(x => x.ID).Where(x => 1 == 1);

            if (search.UserID > 0)
            {
                data = data.Where(x => x.ID == search.UserID);
            }

            var pageResult = data.ToList();
            PageSearchResult<T_User> pageViewResult = new PageSearchResult<T_User>()
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
