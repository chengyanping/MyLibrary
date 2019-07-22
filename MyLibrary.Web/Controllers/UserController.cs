using MyLibrary.Model.ViewModel;
using MyLibrary.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyLibrary.BLL;
using MyLibrary.Web.Auth;
using MyLibrary.Web.Filter;

namespace MyLibrary.Web.Controllers
{
    [UserAuthorize(Roles = "User,Admin")]
    public class UserController : BaseController
    {
        private User userBLL = new BLL.User();
        // GET: User
        public ActionResult Index()
        {
            SetPageSeo("个人中心");
            return View();
        }

        public new ActionResult Profile()
        {
            SetPageSeo("个人信息");

            if (user == null)
            {
                return RedirectToAction("Login", "Home", null);
            }
            var userinfo = userBLL.GetUserInfo(user.UserId);
            return View(userinfo);
        }

        public ActionResult UpdatePwd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePwd(UserUpdatePwdModel userUpdate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<string> msgList = new List<string>();
            /*
            var userinfo = 1;// userLogic.GetUserInfo(user.UserId);
           
            if (userinfo.Password != userUpdate.OldPwd)
            {
                msgList.Add("旧密码不正确");
            }
            if (userUpdate.Password != userUpdate.ConfirmPwd)
            {
                msgList.Add("两次输入密码不一致");
            }
            */

            msgList.Add("两次输入密码不一致");
            if (msgList.Count > 0)
            {
                ViewBag.MsgList = msgList;
                return View();
            }

            // userinfo.Password = Md5.GetMd5(userUpdate.Password);
            bool updateResult = true; // userLogic.UpdateUserPwd(userinfo.ID, userinfo.Password);
            ViewBag.Msg = updateResult ? "修改成功" : "修改失败";
            return View();
        }

        public ActionResult Collect()
        {
            return View();
        }

        public ActionResult PostList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JokeList(int page = 1)
        {
            UserBookSearchModel search = new UserBookSearchModel();
            search.UserId = user.UserId;
            search.Page = page;

            var pageViewResult = 1; // jokeLogic.UserJokesSearch(search);
            return View(pageViewResult);
        }



        public void Logout()
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/home/index");
            //return RedirectToAction("Index","Home",null);
        }

      

    }
}