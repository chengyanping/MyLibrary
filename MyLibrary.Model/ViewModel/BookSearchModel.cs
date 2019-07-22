using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Model.ViewModel
{
    public class BookSearchModel : BaseSearchModel
    {
        public int PostUserId = 0;
        public string CategoryPinyin = "";
        public BookSearchType SearchType = BookSearchType.Latest;
        public int CategoryID { set; get; }
    }
}
