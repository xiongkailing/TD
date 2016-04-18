using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDay.WebSite.Infrastructure;

namespace TeamDay.WebSite.SessionManager
{
    public class RedisSessionManageService:ISessionManageService
    {
        public UserSession GetBySessionId(string sessionId)
        {
            throw new NotImplementedException();
        }

        public void Update(string sessionId, UserSession session)
        {
            throw new NotImplementedException();
        }

        public UserSession GetCurrentSession(System.Web.HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
