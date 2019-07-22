using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyLibrary.Model.Domain;
using MyLibrary.Model.ViewModel;

namespace MyLibrary.SQLServerDAL
{
    public class EFDbContext:DbContext
    {
      
        public EFDbContext():base("name=MyLibraryDB")
        {

        }

        public DbSet<T_User> Users { get; set; }
        public DbSet<T_UserLog> UserLogs { get; set; }

        public DbSet<T_GetPwd> GetPwds { get; set; }

        public DbSet<T_Category> Categories { get; set; }

        public DbSet<T_Book> Books { get; set; }
    }
}
