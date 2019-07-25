using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace MyLibrary.Model.Domain
{
    /// <summary>
    /// 用户信息表
    /// </summary>
  
    [Table("T_User")]
    public partial class T_User
    {
      
        /// <summary>
        /// 用户ID
        /// </summary>
        [Key]
        [Column("UserId",TypeName ="Int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get;set;
        }
        /// <summary>
        ///  用户名
        /// </summary>
       
        public int? ReaderTypeId { get; set; }

        [Column("ReaderName",TypeName = "nvarchar"),MaxLength(32)]
        public string UserName
        {
            get; set;
        }
        /// <summary>
        /// 昵称
        /// </summary>
        [NotMapped]
        public string NikeName
        {
            get; set;
        }
        /// <summary>
        /// 电子邮件
        /// </summary>
        [Column("ReaderSex",TypeName = "nvarchar"),MaxLength(2)]
        public string ReaderSex { get; set; }

        [Column("ReaderPhone",TypeName = "nvarchar"),MaxLength(32)]
        public string ReaderPhone { get; set; }

        [Column("ReaderEmail",TypeName = "nvarchar"),MaxLength(32)]
        public string Email
        {
            get; set;
        }

        [Column("ReaderStatus",TypeName ="Int")]
        public int ReaderStatus { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Column("ReaderPwd",TypeName = "nvarchar"),MaxLength(32)]
        public string Password
        {
            get; set;
        }

        
        
        /// <summary>
        /// 注册日期
        /// </summary>
        [Column("ReaderDate")]
        public DateTime RegisterDate
        {
            get; set;
        }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        [Column("LastLogin")]
        public DateTime LastLogin
        {
            get; set;
        }
        /// <summary>
        /// 用户头像
        /// </summary>
        [Column("ReaderPhoto",TypeName = "nvarchar"),MaxLength(256)]

        public string Photo
        {
            get; set;
        }

     
        
        /// <summary>
        /// 用户状态
        /// </summary>
        public int? State
        {
            get;set;
        }
        /// <summary>
        /// 是否是管理员
        /// </summary>
        [Column("IsAdmin")]
        public int? IsAdmin
        {
            get; set;
        }

        public virtual T_ReaderType ReaderType { get; set; }

        public  ICollection<T_UserLog> Logs { get; set; }
    }
}
