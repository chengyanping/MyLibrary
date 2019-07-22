using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MyLibrary.Common;

namespace MyLibrary.Web.Helpers
{
    public class AppConfig
    {
        public static readonly int IsQiniuUpload;
        public static readonly string QiniuCloudUrl;
        public static readonly string JokeImgUpload;
        public static readonly int IsEnableComment;
        public static readonly string HotCategories;
        public static readonly string SendCloudKey;
        static AppConfig()
        {
            IsQiniuUpload = Convert.ToInt32(ConfigurationManager.AppSettings["IsQiniuUpload"]);
            QiniuCloudUrl = ConfigurationManager.AppSettings["QiniuCloudUrl"];
            JokeImgUpload = ConfigurationManager.AppSettings["JokeImgUpload"];
            IsEnableComment = Convert.ToInt32(ConfigurationManager.AppSettings["IsEnableComment"]);  
            HotCategories = ConfigurationManager.AppSettings["HotCategories"];
            SendCloudKey = ConfigurationManager.AppSettings["SendCloudSK"];
        }
    }
}