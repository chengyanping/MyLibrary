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
            Database.SetInitializer<EFDbContext>(new DropCreateDatabaseIfModelChanges<EFDbContext>());
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention
            // If you keep this convention then the generated tables will have pluralized names.
        
         
        }
        public DbSet<T_User> Users { get; set; }
        public DbSet<T_UserLog> UserLogs { get; set; }

        public DbSet<T_GetPwd> GetPwds { get; set; }

        public DbSet<T_Category> Categories { get; set; }

        public DbSet<T_Book> Books { get; set; }
        public DbSet<T_BorrowedRecord> BorrowedRecords { get; set; }
        public DbSet<T_Comment> Comments { get; set; }
        public DbSet<T_Favorite> Favorites { get; set; }
    
        public DbSet<T_Reserved> Reserved { get; set; }
        public DbSet<T_BookList> BookList { get; set; }
        public DbSet<T_BookListItem> BookListItem { get; set; }
        
        public DbSet<T_Money> Money { get; set; }

        public DbSet<T_RecommendedBook> RecommendedBook { get; set; }

        public DbSet<T_RecommendedBookList> RecommendedBookList { get; set; }


    }
}
