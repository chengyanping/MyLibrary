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
            Database.SetInitializer<EFDbContext>(new CreateDatabaseIfNotExists<EFDbContext>());
           
        }

        public DbSet<T_User> Users { get; set; }
        public DbSet<T_UserLog> UserLogs { get; set; }

        public DbSet<T_GetPwd> GetPwds { get; set; }

        public DbSet<T_Category> Categories { get; set; }

        public DbSet<T_Book> Books { get; set; }
        public DbSet<T_BorrowedRecord> BorrowedRecords { get; set; }
        public DbSet<T_Comment> Comments { get; set; }
        public DbSet<T_Favorite> Favorites { get; set; }
        public DbSet<T_Fine> Fines { get; set; }
        public DbSet<T_Reserved> Reserved { get; set; }
        public DbSet<T_ReturnRecord> ReturnRecords { get; set; }
      
    }
}
