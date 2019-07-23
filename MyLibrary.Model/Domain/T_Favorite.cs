using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model.Domain
{

    public class T_Favorite
    {
        [Key]
        [Column("FavoriteId"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FavoriteId { get; set; }

     
        [Column("BookId")]
        public int BookId { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("BookName",TypeName = "nvarchar"),MaxLength(128)]
        public string BookName { get; set; }

        public T_User User { get; set; }
        public T_Book Book { get; set; }


    }
}
