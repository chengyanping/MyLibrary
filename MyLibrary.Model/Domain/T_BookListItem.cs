using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model.Domain
{
    public class T_BookListItem
    {
        [Key]
        [Column("BookListItemId"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookListItemId { get; set; }
        public int BookListId { get; set; }
        public int BookId { get; set; }

        [Column("Description", TypeName = "nvarchar"), MaxLength(1024)]
        public string Description { get; set; }

   
        public virtual T_BookList BookList { get; set; }
     
        public virtual T_Book Book { get; set; }
    }
}
