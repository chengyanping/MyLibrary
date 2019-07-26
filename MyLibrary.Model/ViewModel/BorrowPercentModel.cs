using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Model.ViewModel
{
    public  class BorrowPercentModel
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { set; get; }
      
        /// <summary>
        /// 每个分类所借数量
        /// </summary>
        public double CategoryNum { set; get; }
        /// <summary>
        /// 每个分类所占百分比
        /// </summary>
        public double CategoryPercent { set; get; }

    }
}
