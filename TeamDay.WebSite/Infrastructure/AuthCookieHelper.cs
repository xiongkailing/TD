using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TeamDay.Helpers;
using TeamDay.Models.EfModels;

namespace TeamDay.WebSite.Infrastructure
{
    public class AuthCookieHelper
    {
        public static void AddCookie(HttpCookieCollection cookies,User user)
        {
            /*identity格式:"Code|MD5密码|角色|Cookie生成时间|名称"*/
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}|{1}|{2}|{3}|{4}", user.Code, user.Password, user.Role.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), user.Name);
            string encrpt = CommonHelper.ReverseEncrypt(sb.ToString(), WebConfig.PrivateKey, WebConfig.SIV);
            HttpCookie hc = new HttpCookie("identity", encrpt);
            hc.HttpOnly = true;
            cookies.Add(hc);
        }

        public static string Qstring(User user)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}|{1}|{2}|{3}", user.Code, user.Password, user.Role.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), user.Name);
            return CommonHelper.ReverseEncrypt(sb.ToString(), WebConfig.PrivateKey, WebConfig.SIV);
        }
    }
}