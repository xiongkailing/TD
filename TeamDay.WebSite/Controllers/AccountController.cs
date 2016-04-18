using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeamDay.CoreServices.UserServices;
using TeamDay.CoreServices.VerifycodeServices;
using TeamDay.Helpers;
using TeamDay.WebSite.Filters;
using TeamDay.WebSite.Infrastructure;
using TeamDay.WebSite.Models.AccountModels;

namespace TeamDay.WebSite.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        private IImageVerifyService verifyService;
        public AccountController(IUserService userService, IImageVerifyService verifyService)
        {
            this.userService = userService;
            this.verifyService = verifyService;
        }
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
                var user = userService.LoginValidate(model.Name, CommonHelper.MD5Encrypt(model.Password));
                if(user!=null)
                {             
                    if (!Session.IsCookieless)
                    {
                        AuthCookieHelper.AddCookie(HttpContext.Response.Cookies, user);
                        returnUrl = System.Web.HttpUtility.UrlDecode(returnUrl);
                    }
                    else
                    {
                        Session.Add("i", AuthCookieHelper.Qstring(user));
                        returnUrl += "i=" + AuthCookieHelper.Qstring(user);
                    }
                    return Redirect(returnUrl);
                }
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
            this.verifyService.Add(new TeamDay.Models.RedisModels.VerifyCode { Code = code.Code, Id = code.Id, Time = DateTime.Now });
            return PartialView("VerifyCode", code);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            return View();
        }

        public ActionResult EmailValidate()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {          
            this.userService=null;
            this.verifyService=null;
            base.Dispose(disposing);
        }
    }
}