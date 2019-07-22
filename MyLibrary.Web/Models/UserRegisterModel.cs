using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MyLibrary.Web.Models
{
    public class UserRegisterModel
    {
      
        public string UserName { set; get; }

     
        //[RegularExpression("[A-Za-z0-9][@][A-Za-z0-9]+[.][A-Za-z0-9]")]
        public string Email { set; get; }

      
        public string Password { set; get; }

     
        public string RepeatPwd { set; get; }

       
        public string VerifyCode { set; get; }
    }
}