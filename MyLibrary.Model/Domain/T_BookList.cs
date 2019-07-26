using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model.Domain
{
    //书单
    public class T_BookList
    {
        [Key]
        [Column("BookListId"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookListId { get; set; }

        public int UserID
        {
            get; set;
        }

        [Column("Title", TypeName = "nvarchar"), MaxLength(128)]
        public string Title { get; set; } //书单名称

        public DateTime CreateTime { get; set; } //创建时间

        [Column("Description", TypeName = "nvarchar"), MaxLength(1024)]
        public string Description { get; set; } //描述

        public DateTime ModifyTime { get; set; } //修改时间

      
    

        public virtual T_User User { get; set; }
        public virtual ICollection<T_BookListItem> BookListItems { get; set; }
    }
}
