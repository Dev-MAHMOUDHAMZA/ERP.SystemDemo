using ERP.Domain.Constants.GlobalConst;
using Microsoft.AspNetCore.Authorization;

namespace ERP.Web.Permission
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        public PermissionAuthorizationHandler()
        {

        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
                return;

            var Permission = context.User.Claims
                .Where(x => x.Type == ConstPermission.Permission && x.Value == requirement.Permission && x.Issuer == ConstPermission.LOCALAUTHORITY);

            if (Permission.Any())
            {
                context.Succeed(requirement);
                return;
            }
        }
    }
}
