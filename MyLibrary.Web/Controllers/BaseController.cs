using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MyLibrary.Web.Auth;

namespace MyLibrary.Web.Controllers
{
    public class BaseController:Controller
    {
        protected UserInfoPrincipal user = System.Web.HttpContext.Current.User as UserInfoPrincipal;
        protected string BookImgUpload = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["BookImgUpload"]);
        protected string BookImgUploadConfig = ConfigurationManager.AppSettings["BookImgUpload"];
        protected string SiteTitle = ConfigurationManager.AppSettings["SiteTitle"];
        protected string SiteKeyWords = ConfigurationManager.AppSettings["SiteKeyWords"];
        protected string SiteDescription = ConfigurationManager.AppSettings["SiteDescription"];
        

        protected void SetPageSeo(string title,string keywords="",string description="")
        {
            ViewBag.Title = title;
            ViewBag.KeyWords = keywords;
            ViewBag.Description = description;
        }

        protected void RedirectUrl(string url)
        {
            Response.Clear();
            Response.BufferOutput = true;
            if(Response.IsRequestBeingRedirected)
            {
                Response.Redirect(url,true);
            }
        }
    }
}