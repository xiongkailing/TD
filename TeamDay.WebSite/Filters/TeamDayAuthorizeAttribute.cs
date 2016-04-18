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
    public class TeamDayAuthorizeAttribute : AuthorizeAttribute
    {
        public IUserService userService { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            /*identity格式:"Code|MD5密码|角色|Cookie生成时间|名称"*/
            string identity = "";
            if (httpContext.Session.IsCookieless)
            {
                string encrptInfo = httpContext.Request.QueryString.Get("i");
                if (string.IsNullOrEmpty(encrptInfo))
                    return false;
                else
                    identity = encrptInfo;
            }
            else
            {
                var identityCookie = httpContext.Request.Cookies.Get("identity");
                if (identityCookie != null)
                {
                    identity = identityCookie.Value;
                }
                else
                    return false;
            }
            string raw = CommonHelper.ReverseDecrypt(identity, WebConfig.PrivateKey, WebConfig.SIV);
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
            string loginUrl = "~/Account/Login";
            //TODO:
            filterContext.Result = new RedirectResult(loginUrl + "?returnUrl=" + System.Web.HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.PathAndQuery));
        }
    }
}