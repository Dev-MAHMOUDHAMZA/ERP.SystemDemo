using ERP.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ERP.Web.Extensions;
public static class UserExtension
{
    public static string GetUserId(this ClaimsPrincipal user) =>
        user.FindFirstValue(ClaimTypes.NameIdentifier)!;

    //public static int GetBranchId(this ClaimsPrincipal user, UserManager<Employee> _userManager) =>
    //    (int)_userManager.FindByIdAsync(user.GetUserId())?.Result?.EmployeePositions.FirstOrDefault(ep => ep.IsMainPosition).Position?.Department?.BranchId;

    //public static int GetDepartmentId(this ClaimsPrincipal user, UserManager<Employee> _userManager) =>
    //    (int)_userManager.FindByIdAsync(user.GetUserId())?.Result?.EmployeePositions.FirstOrDefault(ep => ep.IsMainPosition).Position?.DepartmentId;


}
