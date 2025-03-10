using Application.IServices;
using ERP.Web.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace ERP.Web.Controllers;
public class HomeController(ILogger<HomeController> _logger, ISD _sD) : Controller
{


    public IActionResult Index()
    {
        decimal number = 2545.44m;
        string textDecimalToWords = _sD.ConvertDecimalToWords(number, "جنيه مصري", "قرش");
        return View((object)textDecimalToWords);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
