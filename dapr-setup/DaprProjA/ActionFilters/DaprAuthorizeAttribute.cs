using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DaprProjA.ActionFilters;

public class DaprAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var clientIp = context.HttpContext.Connection.RemoteIpAddress?.ToString(); // Get real sender IP

        if (IsLocalhost(clientIp) is false)
        {
            context.Result = new ForbidResult();
        }
    }

    private bool IsLocalhost(string? ip)
    {
        return ip == "::1" || ip == "127.0.0.1";
    }
}