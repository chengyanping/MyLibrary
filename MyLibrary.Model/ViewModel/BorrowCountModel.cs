using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Model.ViewModel
{
    public class BorrowCountModel
    {
        public int UserId { get; set; }//用户编号
        public int BorrowCount { get; set; }//借阅总数量
        public int ReturnedCount { get; set; }//已归还数量
        public int NoReturnedCount { get; set; }//未归还数量
        public int AspirationCount { get; set; }//心仪数量
        public int CollectionCount { get; set; }//收藏数量
    }
}
