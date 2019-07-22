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
    [Serializable]
    public partial class T_Comment
    {
     
      
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
        public string Content
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
        /// 发表人id
        /// </summary>
        public int BookId
        {
            get; set;
        }
        /// <summary>
        /// 楼层
        /// </summary>
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
   

    }
}
