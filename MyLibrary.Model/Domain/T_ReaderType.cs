using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model.Domain
{
    [Table("T_ReaderType")]
    public class T_ReaderType
    {
        [Key]
        [Column("ReaderTypeId"),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReaderTypeId { get; set; }

        [Column("ReaderTypeName",TypeName = "nvarchar"),MaxLength(16)]
        public string ReaderTypeName { get; set; }
        public int CanBorrowQty { get; set; }
        public int CanBorrowDay { get; set; }
        public int CanContinueTimes { get; set; }
        public float PunishRate { get; set; }
        public int BookTypeId { get; set; } 
 
        public ICollection<T_User> Users { get; set; }
    }
}
