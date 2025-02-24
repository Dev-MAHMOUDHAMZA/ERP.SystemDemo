using ERP.BL.ServicesBL;
using ERP.Domain.Entities.Common;
using static ERP.Domain.Enums.EnumHelper;
using ERP.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ERP.Web.Controllers;
public class AccountsController(ILogger<AccountsController> _logger, SignInManager<Employee> _signInManager, AccountsServicesBL _accountsServicesBL) : Controller
{
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "يجب ادخال رقم الهوية وكلمة المرور");
                return View(model);
            }

            var (loginResult, user) = await _accountsServicesBL.LoginUser(model);

            if (loginResult == (int)eLoginResult.SuccessfulLogin && user is not null)
            {
                await _signInManager.SignInAsync(user, isPersistent: model.RememberMe);
                return RedirectToAction("Index", "Company");
            }

            string errorMessage = loginResult switch
            {
                (int)eLoginResult.UserInactive => "عفوًا! لا يمكنك الدخول، حسابك معطل برجاء التواصل مع الادارة",
                _ => "يجب ادخال رقم هوية وكلمة مرور صحيحة"
            };

            ModelState.AddModelError(string.Empty, errorMessage);
            return View(model);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in Login function");
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    //public async Task<IActionResult> Login(LoginViewModel model)
    //{
    //    try
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var (loginResult, user) = await _accountsServicesBL.LoginUser(model);
    //            switch (loginResult)
    //            {
    //                case (int)eLoginResult.SuccessfulLogin:
    //                    if(user is not null)
    //                    {
    //                        await _signInManager.SignInAsync(user, isPersistent: model.RememberMe);
    //                        return RedirectToAction("Index", "Company");
    //                    }
    //                    ModelState.AddModelError(string.Empty, "يجب ادخال رقم هوية وكلمة مرور صحيحة");
    //                    break;

    //                case (int)eLoginResult.UserInactive:
    //                    ModelState.AddModelError(string.Empty, "عفوًا! لا يمكنك الدخول، حسابك معطل برجاء التواصل مع الادارة");
    //                    break;

    //                default:
    //                    ModelState.AddModelError(string.Empty, "يجب ادخال رقم هوية وكلمة مرور صحيحة");
    //                    break;

    //            }
    //            ;
    //            return (View(model));
    //        }
    //        ModelState.AddModelError(string.Empty, "يجب ادخال رقم الهوية وكلمة المرور");
    //        return (View(model));
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "function login");
    //        return StatusCode((int)HttpStatusCode.InternalServerError);
    //    }

    //}
}
