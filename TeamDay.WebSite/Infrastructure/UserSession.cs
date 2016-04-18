using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using TeamDay.Helpers;
using TeamDay.WebSite.SessionManager;

namespace TeamDay.WebSite.Infrastructure
{
    public class UserSession
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Code { get; set; }
        public string Id { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsRemember { get; set; }
        public static UserSession GetCurrentUser(HttpContext context)
        {
            var identity = context.Request.Cookies.Get("identity");
            string raw = CommonHelper.ReverseDecrypt(identity.Value, WebConfig.PrivateKey, WebConfig.SIV);
            string[] infos = raw.Split('|');
            IFormatProvider culture = new CultureInfo("zh-CN", true);
            return new UserSession
            {
                Code = infos[0],
                Name = infos[4],
                CreateTime = DateTime.Parse(infos[3], culture, DateTimeStyles.NoCurrentDateDefault),
                Role = infos[2]
            };
        }

        public static bool IsAuthorized
        {
            get
            {
                var identity = HttpContext.Current.Request.Cookies.Get("identity");
                return identity != null;
            }
        }
    }
}