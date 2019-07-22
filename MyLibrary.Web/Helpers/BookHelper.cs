using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

using MyLibrary.Common;
using MyLibrary.Model.ViewModel;
using Microsoft.Security.Application;

namespace MyLibrary.Web.Helpers
{
    public class BookHelper
    {
        public static string GetBookDetail(int jokeid)
        {
            return string.Format("/Book{0}.html",jokeid);
        }

        public static string GetCategoryBooks(string pinyin)
        {
            return "aa";
            //return string.Format("/{0}.html",pinyin.ToLower());
        }
      

        public static string RemoveHtml(string content)
        {
            return Sanitizer.GetSafeHtmlFragment(content);
        }
    }
}