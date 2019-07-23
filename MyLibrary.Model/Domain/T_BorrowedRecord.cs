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

        public DateTime? OutDate { get; set; }

        public DateTime? InDate { get; set; }

        public int? Status { get; set; } //是否已经还书

        public int? IsRenewCount { get; set;  } //是否续借

        public T_User User { get; set; }
        public T_Book Book { get; set; }

        
    }
}
