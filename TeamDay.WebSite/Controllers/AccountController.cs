using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamDay.Helpers;
using TeamDay.WebSite.Filters;
using TeamDay.WebSite.Models.AccountModels;

namespace TeamDay.WebSite.Controllers
{
    //[TeamDayAuthorize]
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl = "%2fHome%2fIndex")
        {
            if (ModelState.IsValid) 
            { 
                
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            return View();
        }
        public ActionResult VerifyCode()
        {
            VerifyCode code = new VerifyCode();
            //使用Redis 缓存 验证码
            return PartialView("VerifyCode", code);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            return View();
        }
    }
}