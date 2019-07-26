using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model.Domain
{
    public class T_RecommendedBook
    {
        [Key]
        [Column("RecommendedBookId"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int RecommendedBookId { get; set;}

        public int BookId { get; set; }
        public DateTime CreateTime { get; set; } //创建时间

        [Column("Description", TypeName = "nvarchar"), MaxLength(1024)]
        public string Description { get; set; } //描述

        public DateTime ModifyTime { get; set; } //修改时间

        public virtual T_Book Book { get; set; }
    }
}
