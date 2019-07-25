using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Model.Domain
{
    //存放web和微信所用的图书封面
    [ComplexType]
    public class BookCover
    {
        public string Large { get; set; }
        public string Small { get; set; }
    }
}
