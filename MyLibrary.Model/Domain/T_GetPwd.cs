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
    /// 找回密码
    /// </summary>
    [Serializable]
    [Table("T_GetPwd")]
    public partial class T_GetPwd
    {
      
        /// <summary>
        /// 主键
        /// </summary>
        [Column("GetPwdId")]
        public int ID
        {
            get; set;
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            get; set;
        }
        /// <summary>
        /// Guid
        /// </summary>
        [Column("Guid",TypeName = "nvarchar"),MaxLength(128)]
        public string Guid
        {
            get; set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddDate
        {
            get; set;
        }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpireDate
        {
            get; set;
        }

        /// <summary>
        /// 有效状态
        /// </summary>
        public int State
        {
            get;set;
        }

        public T_User User { get; set; }


    }
}
