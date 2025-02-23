﻿using Hangfire.Dashboard;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.CodeAnalysis;

namespace ERP.Web.Common;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    private string _policyName;

    public HangfireAuthorizationFilter(string policyName)
    {
        _policyName = policyName;
    }

    public bool Authorize([NotNull] DashboardContext context)
    {
        var httpContext = context.GetHttpContext();
        var authService = httpContext.RequestServices.GetRequiredService<IAuthorizationService>();

        return authService.AuthorizeAsync(httpContext.User, _policyName)
                                     .ConfigureAwait(false).GetAwaiter().GetResult().Succeeded;
    }
}
