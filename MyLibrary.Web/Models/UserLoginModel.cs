﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyLibrary.Web.Models
{
    public class UserLoginModel
    {
        [Required]
        public string UserName { set; get; }

        [Required]
        public string Password { set; get; }

        [Required]
        public string VerifyCode { set; get; }
    }
}