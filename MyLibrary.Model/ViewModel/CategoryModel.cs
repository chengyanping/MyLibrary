﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Model.ViewModel
{
    public class CategoryModel
    {
        public int CategoryID { set; get; }
        public string CategoryName { set; get; }

        public string PinYin { set; get; }

     //   public List<T_Joke> JokeInfos { set; get; }
        public int TotalCount { set; get; }
    }
}
