using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model.Domain;

namespace MyLibrary.Model.ViewModel
{
   public  class hotBooks
    {
        public int BookId { get; set; }
        public int num { get; set; }
        public  T_Book Book { get; set; }
    }
}
