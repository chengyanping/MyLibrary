using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using MyLibrary.Web.Auth;
using Newtonsoft.Json;
using MyLibrary.Web.App_Start;

namespace MyLibrary.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfig.CustomizeConfig(GlobalConfiguration.Configuration);
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                UserInfo userinfo = JsonConvert.DeserializeObject<UserInfo>(authTicket.UserData);
                UserInfoPrincipal newUser = new UserInfoPrincipal(userinfo.UserName);
                newUser.UserId = userinfo.UserID;
                newUser.UserName = userinfo.UserName;
                newUser.IsAdmin = userinfo.IsAdmin;

                HttpContext.Current.User = newUser;
            }
        }
    }
}
