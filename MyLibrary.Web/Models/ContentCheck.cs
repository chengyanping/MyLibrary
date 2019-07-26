using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyLibrary.Web.Models
{
    public class ContentCheck
    {
        [Required]
        public string content { set; get; }
        [Required]
        public string type { get; set; }

    }
}