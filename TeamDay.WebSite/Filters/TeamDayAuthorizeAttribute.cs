using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamDay.CoreServices.UserServices;
using TeamDay.Helpers;
using TeamDay.Models.EfModels;
using TeamDay.WebSite.Infrastructure;

namespace TeamDay.WebSite.Filters
{
    public class TeamDayAuthorizeAttribute:AuthorizeAttribute
    {
        public IUserService userService { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            /*identity格式:"用户名|MD5密码|角色|Cookie生成时间"*/
            var identity = httpContext.Request.Cookies.Get("identity");
            if (identity != null)
            {
                string raw = CommonHelper.ReverseDecrypt(identity.Value,WebConfig.PrivateKey,WebConfig.SIV);
                string[] infos = raw.Split('|');
                User pwd = this.userService.PasswordValidate(infos[0], infos[1]);
                if (pwd == null)
                    return false;
                else
                {
                    var role = pwd.Role;
                    if (string.IsNullOrEmpty(Roles)) { Roles = "Ordinary"; }
                    return role.ToString() == Roles && infos[2] == Roles;
                }
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        Message = "Ajax_UnAuthorized"
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            string loginUrl = "/Account/Login";
            //TODO:
            filterContext.Result = new RedirectResult(loginUrl + "?returnUrl=" + filterContext.HttpContext.Request.Url.PathAndQuery);
        }
    }
}