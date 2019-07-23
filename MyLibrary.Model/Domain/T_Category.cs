using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Model.Domain
{
    /// <summary>
    /// 分类
    /// </summary>
    [Serializable]  
    public partial class T_Category
    {
       
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get;set;
        }
        /// <summary>
        /// 分类名称
        /// </summary>
        [Column("Name",TypeName = "nvarchar"),MaxLength(32)]
        public string Name
        {
            get; set;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            get; set;
        }
        /// <summary>
        /// 有效状态
        /// </summary>
        public int State
        {
            get; set;
        }

        [Column("PinYin",TypeName = "nvarchar"),MaxLength(32)]
        public string PinYin
        {
            get;set;
        }


        public ICollection<T_Book> Books { get; set; }

    }
}
