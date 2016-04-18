using System;
using System.Web;
using TeamDay.Helpers;
using TeamDay.WebSite.Infrastructure;

namespace TeamDay.WebSite.SessionManager
{
    public class DefaultSessionManageService : ISessionManageService
    {
        public UserSession GetCurrentSession(HttpContext context)
        {
            var identity = context.Request.Cookies.Get("identity");
            string raw = CommonHelper.ReverseDecrypt(identity.Value, WebConfig.PrivateKey, WebConfig.SIV);
            string[] infos=raw.Split('|');
            return new UserSession { Code = infos[0], Name = infos[3], CreateTime = DateTime.Parse(infos[2]), Role = infos[1] };
        }

        public UserSession GetBySessionId(string sessionId)
        {
            throw new NotImplementedException();
        }

        public void Update(string sessionId, UserSession session)
        {
            throw new NotImplementedException();
        }
    }
}