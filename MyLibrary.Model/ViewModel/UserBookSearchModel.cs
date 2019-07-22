using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Model.ViewModel
{
    public class UserBookSearchModel:BaseSearchModel
    {
        public int? UserId { set; get; }
        public int? BookType { set; get; }

        public int? BookState { set; get; }
    }
}
