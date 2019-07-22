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
    /// 用户操作日志
    /// </summary>
    [Serializable]
    [Table("T_UserLog")]
    public partial class T_UserLog
    {
      
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get;set;
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("UserId")]
        public int UserID
        {
            get; set;
        }
        /// <summary>
        /// 用户名
        /// </summary>
        [Column("UserName",TypeName ="varchar"),MaxLength(32)]
        public string UserName
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
        /// 操作备注
        /// </summary>
        [Column("Content",TypeName ="varchar"),MaxLength(1024)]
        public string Content
        {
            get;set;
        }
       

    }
}
