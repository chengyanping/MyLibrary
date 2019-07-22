using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace MyLibrary.DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];

        private DataAccess() { }

        public static MyLibrary.IDAL.IUser CreateUser()
        {
            string className = path + ".User";
            return (MyLibrary.IDAL.IUser)Assembly.Load(path).CreateInstance(className);
        }

        public static MyLibrary.IDAL.IUserLog CreateUserLog()
        {
            string className = path + ".UserLog";
            return (MyLibrary.IDAL.IUserLog)Assembly.Load(path).CreateInstance(className);
        }
        public static MyLibrary.IDAL.IGetPwd CreateGetPwd()
        {
            string className = path + ".GetPwd";
            return (MyLibrary.IDAL.IGetPwd)Assembly.Load(path).CreateInstance(className);
        }

        public static MyLibrary.IDAL.ICategoryInfo CreateCategoryInfo()
        {
            string className = path + ".CategoryInfo";
            return (MyLibrary.IDAL.ICategoryInfo)Assembly.Load(path).CreateInstance(className);


        }


        public static MyLibrary.IDAL.IBook CreateBook()
        {
            string className = path + ".Book";
            return (MyLibrary.IDAL.IBook)Assembly.Load(path).CreateInstance(className);


        }
    }
}
