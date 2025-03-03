using Application.IUnitOfWork;
using ERP.Domain.Constants.GlobalConst;
using ERP.Domain.Entities.Common;
using ERP.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using static ERP.Domain.Enums.EnumHelper;

namespace ERP.BL.ServicesBL;

public class AccountsServicesBL (UserManager<Employee> _userManager, 
    IUnitOfWork _unitOfWork, ILogger<AccountsServicesBL> _logger)
{
    #region Methods

    public async Task<(int, Employee?)> LoginUser(LoginViewModel model)
    {
        try
        {
            var user = await _unitOfWork.Employees.GetItemAsync(u => u.Email == model.Email);

            if (user is null)
                return ((int)eLoginResult.UserNotFound, null);

            if (!user.IsActive)
                return ((int)eLoginResult.UserInactive!, null);

            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, model.Password);

            return isPasswordCorrect
                ? ((int)eLoginResult.SuccessfulLogin, user)
                : ((int)eLoginResult.WrongPasswordEmail, null);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while logging in user.");
            return ((int)eLoginResult.Error, null);
        }
    }

    //public async Task<(int, Employee)> LoginUser(LoginViewModel model) {
    //    try
    //    {
    //        var user = _unitOfWork.Employees.GetItem(u => u.Email.Equals(model.Emial));
    //        var result = await _userManager.CheckPasswordAsync(user, model.Password);

    //        if (user is null)
    //            return ((int) eLoginResult.WrongPasswordNationalId!, null!);

    //        if (user.Email == ConstDefaultUser.DefaultNationalId)
    //            if (result)
    //                return ((int)eLoginResult.SuccessfulLogin!, user);
    //            else
    //                return ((int)eLoginResult.WrongPasswordNationalId!, null!);


    //        //var UserBranchId = user.EmployeePositions!.FirstOrDefault(e=>e.IsMainPosition)?.Position?.Department!.BranchId;
    //        //if (result)
    //        //{
    //        //    if (user.IsUser)
    //        //    {
    //        //        if (!user.IsActive || !user.EmployeePositions!.FirstOrDefault(e=>e.IsMainPosition).Position.IsActive || !user.EmployeePositions!.FirstOrDefault(e => e.IsMainPosition).Position.Department.IsActive || !_unitOfWork.Branches.GetById(UserBranchId??0).IsActive)
    //        //            return ((int)eLoginResult.UserInactive!, null!);

    //        //        return ((int)eLoginResult.SuccessfulLogin!, user);

    //        //    }
    //        //    return ((int)eLoginResult.OnlyEmployee!, null!);

    //        //}
    //        return ((int)eLoginResult.WrongPasswordNationalId!, null!);
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex.Message);
    //        return (0, null!);
    //    }

    //}

    //public async void LogoutUser(string UserID)
    //{
    //    try
    //    {
    //        var result = _userManager.FindByIdAsync(UserID);
    //        if (result != null)
    //        {
    //                //await _signInManager.SignOutAsync();
    //        }
    //        return;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex.Message);
    //        return;
    //    }

    //}

    //public async Task<ApplicationEmployee> GetUserByNationalId(string nationalId)
    //{
    //    //return await _unitOfWork.Employees.ExistItemAsync(n => n.NationalId.Equals(nationalId));
    //    return await _userManager.Users.FirstOrDefaultAsync(u => u.NationalId == nationalId);
    //}
    #endregion
}
