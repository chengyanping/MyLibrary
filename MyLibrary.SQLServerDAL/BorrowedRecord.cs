using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.IDAL;
using MyLibrary.Model.Domain;
using MyLibrary.Model.ViewModel;

namespace MyLibrary.SQLServerDAL
{
    public class BorrowedRecord : IBorrowedRecord
    {
        EFDbContext db = new EFDbContext();
        /// <summary>
        /// 根据用户编号获取用户借阅的未归还图书信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns>返回借阅未归还图书信息的集合</returns>
        public IList<T_BorrowedRecord> GetBorrowedRecordByUserId(int UserId)
        {
            IList<T_BorrowedRecord> list = (from a in db.BorrowedRecords where a.UserId == UserId && a.Status == 0 select a).ToList();
            
            return list;
        }
        /// <summary>
        /// 获取借阅数量
        /// </summary>
        public BorrowCountModel GetCount(int UserId)
        {
            BorrowCountModel borrowcount = new BorrowCountModel();
            borrowcount.BorrowCount = (from a in db.BorrowedRecords where a.UserId == UserId select a).ToList().Count();//借阅总数量
            borrowcount.NoReturnedCount = (from a in db.BorrowedRecords where a.UserId == UserId && a.Status == 0 select a).ToList().Count();//未归还数量
            borrowcount.ReturnedCount = (from a in db.BorrowedRecords where a.UserId == UserId && a.Status != 0 select a).ToList().Count();//已归还数量
            borrowcount.AspirationCount = 0;//心仪数量
            borrowcount.CollectionCount = 0;//收藏数量
            return borrowcount;
        }
        public IList<BorrowPercentModel> GetBorrowCategoryPercent(int UserId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IList<BorrowPercentModel> bplist = new List<BorrowPercentModel>();
            BorrowPercentModel bp = new BorrowPercentModel();
            var list = (from a in db.BorrowedRecords
                        from b in db.Categories
                        where a.UserId == UserId && a.Book.CategoryId == b.CategoryID
                        select new {
                                b.Name
                        }).Distinct().ToList();
            int Counts = db.BorrowedRecords.ToList().Count();
            foreach (var item in list)
            {
                bp.CategoryName = item.Name;                
                bp.CategoryNum = (from a in db.BorrowedRecords where a.Book.Category.Name == item.Name select a).ToList().Count();                
                bp.CategoryPercent= (Counts/ list.Where(a => a.Name == item.Name).ToList().Count())*100;
                bplist.Add(bp);
            }
            return bplist;
        }
        /// <summary>
        /// 获取借阅的所有记录（包含已归还和未归还的）
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns>返回借阅图书记录集</returns>
        public IList<T_BorrowedRecord> GetAllRecordByUserId(int UserId)
        {
            IList<T_BorrowedRecord> list = (from a in db.BorrowedRecords where a.UserId == UserId select a).ToList();
            return list;
        }
        /// <summary>
        /// 根据借阅状态显示借阅图书信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <param name="Status">状态</param>
        /// <returns>返回借阅图书列表</returns>
        public IList<T_BorrowedRecord> GetAllRecordByStatus(int UserId, int Status)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IList<T_BorrowedRecord> list = (from a in db.BorrowedRecords where a.UserId == UserId && a.Status==Status select a).ToList();            
           // string s=list.First().Book.BookCover;
            return list;
        }
        public IList<T_BorrowedRecord> GetAllRecordByStatu(int UserId, int Status)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IList<T_BorrowedRecord> list = (from a in db.BorrowedRecords.Include("Book") where a.UserId == UserId && a.Status == 0 select a).ToList();
            
            return list;
        }
    }
}
