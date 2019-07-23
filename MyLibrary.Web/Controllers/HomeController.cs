using MyLibrary.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Security.Application;
using MyLibrary.BLL;
using MyLibrary.Web.Auth;
using Newtonsoft.Json;
using MyLibrary.Model.Domain;
using MyLibrary.Common;
using MyLibrary.Web.Helpers;
using MyLibrary.Web.Filter;

namespace MyLibrary.Web.Controllers
{
    public class HomeController : BaseController
    {
        User userBLL = new BLL.User();
        Book bookBLL = new BLL.Book();

        

        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {

           string strUserAgent = Request.UserAgent.ToString().ToLower();
            if (!string.IsNullOrEmpty(strUserAgent))
            {
                if (Request.Browser.IsMobileDevice)
                {
                    Response.StatusCode = 301;
                    Response.RedirectLocation = "http://m.superjokes.cn";
                    Response.End();
                }

            }

            //
            SetPageSeo(SiteTitle, SiteKeyWords, SiteDescription);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        [LoginCheck]
        public ActionResult Login()
        {


            if (Request.IsAuthenticated)
            {
                //跳转到个人中心
                return RedirectToAction("Profile", "User", null);
            }

            return View();
        }

        [HttpPost]
        [LoginCheck]
        public ActionResult Login(UserLoginModel userLoginModel)
        {
            SetPageSeo("用户登录");
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<string> msgList = new List<string>();
            string verifyCode = Session["ValidateCode"] as string;
            if (userLoginModel.VerifyCode != verifyCode)
            {
                msgList.Add("验证码输入错误");
            }

            userLoginModel = new UserLoginModel()
            {
                VerifyCode = Sanitizer.GetSafeHtmlFragment(userLoginModel.VerifyCode),
                UserName = Sanitizer.GetSafeHtmlFragment(userLoginModel.UserName),
                Password = userLoginModel.Password
            };

            var userinfo = userBLL.GetUserInfo(userLoginModel.UserName, Md5.GetMd5(userLoginModel.Password));
            if (userinfo != null)
            {
                UserInfo user = new UserInfo(userinfo.ID, userinfo.UserName, userinfo.IsAdmin==null?0:1);
                var userJson = JsonConvert.SerializeObject(user);
                var ticket = new FormsAuthenticationTicket(1, userinfo.UserName, DateTime.Now, DateTime.Now.AddDays(1), true, userJson);
                //FormsAuthentication.SetAuthCookie(userLoginModel.UserName, true);
                string cookieString = FormsAuthentication.Encrypt(ticket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieString);
                authCookie.Expires = ticket.Expiration;
                authCookie.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(authCookie);


                bool isAuth = Request.IsAuthenticated;

                // add log
                if (user.IsAdmin > 0)
                {
                    T_UserLog log = new T_UserLog()
                    {
                        AddDate = DateTime.Now,
                        Content = string.Format("{0}于{1}登录系统", user.UserName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        UserID = user.UserID,
                        UserName = user.UserName
                    };
                    userBLL.AddUserLog(log);
                }

                return RedirectToAction("Profile", "User", null);
            }
            else
            {
                msgList.Add("用户名或密码错误");
                ViewBag.MsgList = msgList;
                return View();
            }



        }
        public ActionResult GetVerifyCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }


        [HttpGet]
        [LoginCheck]
        public ActionResult Register()
        {
            ViewBag.BgClass = "indexPage-body";

            return View();
        }

        [HttpPost]
        [LoginCheck]
        public ActionResult Register(UserRegisterModel userRegister)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            List<string> msgList = new List<string>();
            string verifyCode = Session["ValidateCode"] as string;
            if (userRegister.VerifyCode != verifyCode)
            {
                msgList.Add("验证码输入错误");
            }

            if (!Utility.IsEmail(userRegister.Email))
            {
                msgList.Add("Email输入错误");
            }

            var userinfo = userBLL.GetUserInfoByUserName(userRegister.UserName);
            if (userinfo != null)
            {
                msgList.Add("用户名已存在");
            }

            userinfo = userBLL.GetUserInfoByEmail(userRegister.Email);
            if (userinfo != null)
            {
                msgList.Add("Email已存在");
            }

            if (msgList.Count > 0)
            {
                ViewBag.MsgList = msgList;
                return View();
            }
            T_User userDomain = new T_User()
            {
                UserName = Sanitizer.GetSafeHtmlFragment(userRegister.UserName),
                Email = Sanitizer.GetSafeHtmlFragment(userRegister.Email),
                LastLogin = DateTime.Now,
                NikeName = "",
                Password = Md5.GetMd5(userRegister.Password),
                Photo = "",
                RegisterDate = DateTime.Now,
                IsAdmin = 0,
                State = 1
            };
            int userId = userBLL.AddUser(userDomain);
            if (userId > 0)
            {
                // 发送注册成功提醒邮件
                NoticeMail.SendWelcomeMail(userDomain.UserName, userDomain.Email);
                msgList.Add("注册成功!");
                ViewBag.MsgList = msgList;
                //return RedirectToAction("Profile", "User", null);
            }
            //Response.Write("<script>alert('注册成功，请登录！');</script>");

            return View();
        }

        public ActionResult getpwd()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetPwd(string userEmail)
        {
            JsonViewResult json = new JsonViewResult();
            if (string.IsNullOrEmpty(userEmail) || !Utility.IsEmail(userEmail))
            {
                json.Message = "邮箱格式不正确!";
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            var userinfo = userBLL.GetUserInfoByEmail(userEmail);
            if (userinfo == null)
            {
                json.Success = false;
                json.Message = "找不到用户信息，请确认邮箱输入正确！";
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            var getpwdRecord = userBLL.GetPwdRecord(userinfo.ID);
            if (getpwdRecord != null)
            {
                json.Message = "已发送,请查收邮箱";
                json.Success = true;
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            T_GetPwd getpwd = new T_GetPwd()
            {
                AddDate = DateTime.Now,
                Guid = Guid.NewGuid().ToString("N"),
                UserID = userinfo.ID,
                ExpireDate = DateTime.Now.AddHours(3),
                State = 1
            };

            json.Success = userBLL.AddGetPwdRecord(getpwd);
            json.Message = "已发送,请查收邮箱";
            string url = "http://" + Request.Url.Authority + "/home/ResetPwd?guid=" + getpwd.Guid;
            NoticeMail.GetPassword(userinfo.UserName, userinfo.Email, url);
            return Json(json, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CategorySummary()
        {
            var items = bookBLL.GetCategoryInfos();
            return View(items);
        }
        public ActionResult HotCategoryBooks(int categoryId=1)
        {
            var category = bookBLL.GetCategoryBooks(categoryId);
            return View(category);
           
        }

    }
}