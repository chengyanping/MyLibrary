using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model.Domain
{
   
   
    [Table("T_BorrowedRecord")]
    public class T_BorrowedRecord
    {
        [Key]
        [Column("BorrowedRecordId"),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BorrowedRecordId { get; set; }

      
        public int BookId { get; set; }

       
        public int UserId { get; set; }

        [Column("BookName",TypeName = "nvarchar"),MaxLength(128)]
        public string BookName { get; set; }

        public DateTime? OutDate { get; set; } //借出时间

        public DateTime? InDate { get; set; }  //应该归还时间

        public DateTime? ActualInDate { get; set; } //应该归还时间
        public int? Status { get; set; } //状态 是否已经还书

        public  decimal Fine { get; set; }  //罚款

        public   int FineReason { get; set; }
        public int? IsRenewCount { get; set;  } //这是第几次续借

        [ForeignKey("UserId")]
        public virtual T_User User { get; set; }

      
        public virtual T_Book Book { get; set; }

        
    }
}
