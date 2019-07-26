using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyLibrary.Model.Domain
{
    //推荐书单
    public class T_RecommendedBookList
    {
        [Key]
        [Column("RecommendedBookListId"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecommendedBookListId { get; set; }
        

        public int BookListId { get; set; }

        public int BookId { get; set; }

      

    }
}
