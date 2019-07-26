using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyLibrary.BLL;
using MyLibrary.Web.Auth;
using MyLibrary.Model.Domain;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using MyLibrary.Model.ViewModel;

namespace MyLibrary.Web.Controllers
{
    public class UserCenterController :BaseController
    {
        BorrowedRecord borrow = new BorrowedRecord();

        // GET: UserCenter
        public ActionResult Index()
        {
            IList<T_BorrowedRecord> list =borrow.GetBorrowedRecordByUserId(user.UserId);
            ViewBag.borrowCount = borrow.GetCount(user.UserId);
            ViewBag.Percent = borrow.GetBorrowCategoryPercent(user.UserId);
            ViewBag.UserName = user.UserName;
            return View(list);
        }
        /// <summary>
        /// 获取用户借阅图书类别分类所占百分比
        /// </summary>
        /// <returns></returns>
        public string GetBorrowPerent()
        {
            IList<BorrowPercentModel> list=borrow.GetBorrowCategoryPercent(user.UserId);
            string str = JsonConvert.SerializeObject(list);
            return str;
        }
        /// <summary>
        /// 借阅记录页面
        /// </summary>
        /// <returns>返回所有借阅记录</returns>
        public ActionResult BorrowList() 
        {
            IList<T_BorrowedRecord> list = borrow.GetAllRecordByUserId(user.UserId);
            string s = list.First().Book.BookCover.Large;
            return View(list);
        }
        [HttpPost]
        public string SearchBorrowList(int Status)
        {
            IList<T_BorrowedRecord> list = borrow.GetAllRecordByStatus(user.UserId,Status);
            string str= JsonConvert.SerializeObject(list);
            return str;
        }
        /// <summary>
        /// 未归还
        /// </summary>
        /// <returns></returns>
        public ActionResult NoReturned()
        {
            IList<T_BorrowedRecord> list = borrow.GetAllRecordByStatu(user.UserId, 0);
            return View(list);
        }
        public ActionResult Returned()
        {
            IList<T_BorrowedRecord> list = borrow.GetAllRecordByStatu(user.UserId, 1);
            return View(list);
        }
    }
}