using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model.Domain
{
    /// <summary>
    /// 评论信息
    /// </summary>
 
    [Table("T_Comment")]
    public partial class T_Comment
    {
     
       [Key]
       [Column("CommentId",TypeName ="Int"),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get;set;
        }
        /// <summary>
        /// 
        /// </summary>
       
        public int UserId
        {
            get; set;
        }
        /// <summary>
        /// 评论内容
        /// </summary>
        [Column("Content",TypeName = "nvarchar"),MaxLength(1024)]
        public string Content
        {
            get; set;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Column("AddDate")]
        public DateTime AddDate
        {
            get; set;
        }
        /// <summary>
        /// 发表人id
        /// </summary>
        [Column("BookId")]        
        public int BookId
        {
            get; set;
        }
        /// <summary>
        /// 楼层
        /// </summary>
        [Column("Floor")]
        public int Floor
        {
            get; set;
        }
        public int ReadCount
        {
            get;set;
        }

        public int LikeCount
        {
            get;set;
        }

        public int HateCount
        {
            get;set;
        }

      
        public virtual T_User User { get; set; }

      
        public virtual T_Book Book { get; set; }

    }
}
