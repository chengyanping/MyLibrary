using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model.ViewModel;
using MyLibrary.Model.Domain;

namespace MyLibrary.IDAL
{
   public  interface IBorrowedRecord
    {
        /// <summary>
        /// 获取未归还图书信息
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns>返回未归还结果记录集</returns>
        IList<T_BorrowedRecord> GetBorrowedRecordByUserId(int UserId);
        /// <summary>
        /// 获取借阅总数量、未归还数量、已归还数量、心仪数量、收藏数量
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <param name="BorrowCount">借阅总数量</param>
        /// <param name="ReturnedCount">已归还数量</param>
        /// <param name="NoReturnedCount">未归还数量</param>
        /// <param name="AspirationCount">心仪数量</param>
        /// <param name="CollectionCount">收藏数量</param>
        BorrowCountModel GetCount(int UserId);

        IList<BorrowPercentModel> GetBorrowCategoryPercent(int UserId);
        /// <summary>
        /// 获取所有借阅记录
        /// </summary>
        /// <param name="UserId">用户编号</param>
        /// <returns>返回所有借阅记录</returns>
        IList<T_BorrowedRecord> GetAllRecordByUserId(int UserId);
        IList<T_BorrowedRecord> GetAllRecordByStatus(int UserId,int Status);
        IList<T_BorrowedRecord> GetAllRecordByStatu(int UserId, int Status);
    }
}
