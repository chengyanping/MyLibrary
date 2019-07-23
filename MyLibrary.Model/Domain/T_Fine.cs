using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model.Domain
{
    public class T_Fine
    {
        [Key]
        [Column("FineId"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FineId { get; set; }

        public int BookId { get; set; }

       
        public int UserId { get; set; }

        [Column("BookName", TypeName = "nvarchar"), MaxLength(128)]
        public string BookName { get; set; }

     
        public int BorrowedRecordId { get; set; }


        public DateTime OutDate { get; set; }
        public DateTime InDate { get; set; }
        public decimal Fine { get; set; }

        public int FineCause { get; set; }
        public int CLState { get; set; }

        public T_User User { get; set; }
        public T_Book Book { get; set; }

      
    }
}
