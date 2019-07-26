using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model.Domain
{
    //押金
    public class T_Money
    {
        [Key]
        [Column("MoneyId"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int MoneyId { get; set;  }

        //押金状态
        public int State { get; set; }

        public int UserId { get; set; }

        public  decimal Amount { get; set; } //押金数目

        public  int  IsReturn { get; set; } //押金是否已经退还

        public DateTime DepositTime { get; set; } //交押金时间
        public DateTime RefundTime { get; set; } //退押金时间

        public virtual T_User User { get; set; }
    }
}
