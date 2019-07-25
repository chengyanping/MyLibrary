using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model.Domain
{
    //收藏
    public class T_Favorite
    {
        [Key]
        [Column("FavoriteId"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FavoriteId { get; set; }

     
      
        public int UserId { get; set; }

        public int BookListId { get; set; }


     
      


    }
}
