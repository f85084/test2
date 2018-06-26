using Library;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System;
using System.Web;

namespace Web.Controllers
{
    public class UserController : Controller
    {

        UserWeb userWeb = new UserWeb();

        #region 會員首頁取得

        /// <summary>
        /// 會員首頁取得
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Library.User> users = userWeb.GetUsers()
                    .Where(x => !x.Delete)
                    .ToList();
            return View(users);
        }
        #endregion

        #region 建立會員

        /// <summary>
        /// 建立會員
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Library.User user, string UserAccount, int UserClass)
        {
            UserWeb userWeb = new UserWeb();


            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            bool isSuccess = userWeb.AddUser(user);
            if (isSuccess)
            {
                ViewBag.Msg = "帳號已註冊過";
                return View();
            }
                else {
                        
                if (UserClass == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Message");
                }
            }
           
        }
        #endregion

        #region 明細頁

        /// <summary>
        /// 明細頁
        /// </summary>
        /// <param name="id">會員Id</param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Library.User user = userWeb.GetUsers().Single(g => g.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            if(user.UserClass == 0)
            {
                ViewBag.UserClass = " 管理員";
            }
            else
            {
                ViewBag.UserClass = " 一般";
            }
            return View(user);
        }
        #endregion

        #region 編輯會員資料

        /// <summary>
        /// 編輯會員資料
        /// </summary>
        /// <param name="id">會員Id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Library.User user = userWeb.GetUsers().Single(g => g.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,UserAccount, UserClass, Email, Password, UserName")]Library.User user)
        {
            user.Id = userWeb.GetUsers().Single(g => g.Id == user.Id).Id;

            if (!ModelState.IsValid)
            {
                return View("Edit", user);
            }

            userWeb.SaveUser(user);
            return RedirectToAction("Index");
        }
        #endregion

        #region 刪除會員

        /// <summary>
        /// 刪除會員
        /// </summary>
        /// <param name="id">會員Id</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            userWeb.DeleteUser(id);
            return RedirectToAction("Index");
        }
        #endregion

        #region 會員登入

        /// <summary>
        /// 會員登入
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Library.User user, string UserAccount, string Password)
        {
        //驗證帳號和密碼
            if (userWeb.CheckPassword(UserAccount, Password))
            {
                Session["UserAccount"] = UserAccount;
                List<Library.User> users = userWeb.GetUsers()
               .Where(x => x.UserAccount == UserAccount)
               .ToList();
                foreach (Library.User item in users)
                {
                    int Id = item.Id;
                    int UserClass = item.UserClass;
                    Session["Id"] = Id;
                    Session["UserClass"] = UserClass;
                }

                return RedirectToAction("Index", "Message");
            }
            else
            {
                ViewBag.Msg = "帳號或密碼輸入錯誤...";
                return View();
            }
        }
        #endregion


    }
}