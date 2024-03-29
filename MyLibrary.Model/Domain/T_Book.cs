﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MyLibrary.Model.Domain
{
    [Table("T_Book")]
    public class T_Book
    {

        [Key]
        [Column("BookId"),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Column("ISBN13",TypeName ="nvarchar"),MaxLength(13)]
        public string ISBN13 { get; set; }

        [Column("BookName", TypeName = "nvarchar"), MaxLength(128)]
        public string BookName { get; set; }

        [Column("BookPublisher", TypeName = "nvarchar"), MaxLength(13)]
        public string BookPublisher { get; set; }
        public decimal? BookPrice { get; set; }
        public DateTime? Pubdate { get; set; }

        
        [Column("CategoryId", TypeName = "Int")]
        public int? CategoryId { get; set; }

        [Column("Author", TypeName = "nvarchar"), MaxLength(128)]
        public string Author { get; set; }

        [Column("AuthorIntro", TypeName = "nvarchar"), MaxLength(1024)]
        public string AuthorIntro { get; set; }
        public int? BookNum { get; set; }

        [Column("Summary", TypeName = "nvarchar"), MaxLength(1024)]
        public string Summary { get; set; }

        [Column("BookCatalog", TypeName = "ntext")]
        public string BookCatalog { get; set;  } //目录

        [Column("BookPrim", TypeName = "nvarchar"), MaxLength(32)]
        public string BookPrim { get; set;  } //关键字

      
        public DateTime? BookRecord { get; set; } //登记时间

             
     
        public BookCover BookCover
        {
            get;set;
        }
        

        [Column("Pages", TypeName = "Int")]
        public int? Pages { get; set; } //页数



     
        public virtual T_Category Category { get; set; }

        public  ICollection<T_BorrowedRecord> BorrowedRecords { get; set; }
    }
}
