using ERP.Domain.Constants.GlobalConst;

namespace ERP.Web.Extensions;
public static class SessionContext
{
    public static void SessionMsg(this IHttpContextAccessor _httpContextAccessor, string typeMsg, string titleMsg, string BodyMsg)
    {
        _httpContextAccessor.HttpContext!.Session.SetString(ConstSession.TypeMsg, typeMsg);
        _httpContextAccessor.HttpContext!.Session.SetString(ConstSession.Title, titleMsg);
        _httpContextAccessor.HttpContext!.Session.SetString(ConstSession.BodyMsg, BodyMsg);
    }
}
