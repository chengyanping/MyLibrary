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
   public class BorrowedRecord
    {
        private readonly IBorrowedRecord BorrowDAL = MyLibrary.DALFactory.DataAccess.CreateBorrowedRecord();

        public IList<T_BorrowedRecord> GetBorrowedRecordByUserId(int userId)
        {
            IList<T_BorrowedRecord> list = BorrowDAL.GetBorrowedRecordByUserId(userId);
            return list;
        }
        /// <summary>
        /// 获取所有借阅记录
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public IList<T_BorrowedRecord> GetAllRecordByUserId(int userId)
        {
            IList<T_BorrowedRecord> list = BorrowDAL.GetAllRecordByUserId(userId);
            return list;
        }
        /// <summary>
        /// 获取借阅数量
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns>返回借阅统计数</returns>
        public BorrowCountModel GetCount(int UserId)
        {
            BorrowCountModel borrowCount = BorrowDAL.GetCount(UserId);
            return borrowCount;
        }
        /// <summary>
        /// 获取借阅图书所占百分比
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns>返回用户借阅书籍分类所占百分比信息</returns>
        public IList<BorrowPercentModel> GetBorrowCategoryPercent(int UserId)
        {
            IList < BorrowPercentModel>  borrowPercent= BorrowDAL.GetBorrowCategoryPercent(UserId);
            return borrowPercent;
        }
        /// <summary>
        /// 根据借阅状态显示借阅图书信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <param name="Status">状态</param>
        /// <returns>返回借阅图书列表</returns>
        public IList<T_BorrowedRecord> GetAllRecordByStatus(int UserId, int Status)
        {
           
            IList<T_BorrowedRecord> list = BorrowDAL.GetAllRecordByStatus(UserId,Status);
            return list;
        }
        public IList<T_BorrowedRecord> GetAllRecordByStatu(int UserId, int Status)
        {
          
            IList<T_BorrowedRecord> list = BorrowDAL.GetAllRecordByStatu(UserId, Status);
            return list;
        }

    }
}
