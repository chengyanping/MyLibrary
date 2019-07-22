using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Model.ViewModel
{
    public class BookPostInfo
    {
        public int BookId { set; get; }
        public string Title { set; get; }
        public string Content { set; get; }
        public int LikeCount { set; get; }
        public int HateCount { set; get; }

        public string NikeName { set; get; }

        public string UserID { set; get; }

        public string UserName { set; get; }
        public int BookType { set; get; }

        public int BookState { set; get; }
        public DateTime PostDate { set; get; }

        public string Category { set; get; }

        public string CategoryPinyin { set; get; }
    }
}
