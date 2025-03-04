using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace ERP.Web.Common;

//public class FormAjax : ActionMethodSelectorAttribute
//{
//    public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
//    {
//        var request = routeContext.HttpContext.Request;
//        var isAjax = request.Headers["x-requested-with"] == "XMLHttpRequest";

//        return isAjax;
//    }
//}

public class FormAjax : ActionMethodSelectorAttribute
{
    private const string HeaderKey = "x-requested-with";
    private const string AjaxValue = "XMLHttpRequest";

    public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
    {
        var request = routeContext.HttpContext.Request;

        return request.Headers.TryGetValue(HeaderKey, out var headerValue) &&
               string.Equals(headerValue, AjaxValue, StringComparison.OrdinalIgnoreCase);
    }
}
