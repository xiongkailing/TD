using System.Web;
using TeamDay.WebSite.Infrastructure;

namespace TeamDay.WebSite.SessionManager
{
    public interface ISessionManageService
    {
        UserSession GetCurrentSession(HttpContext context);
        UserSession GetBySessionId(string sessionId);
        void Update(string sessionId, UserSession session);
    }
}
