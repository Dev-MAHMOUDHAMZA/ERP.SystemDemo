using ERP.Web.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace ERP.Web.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        decimal number = 2545.44m;
        string textDecimalToWords = ConvertDecimalToWords(number, "جنيه مصري", "قرش");
        return View((object)textDecimalToWords);
    }

    public static string ConvertDecimalToWords(decimal number, string mainCurrency = "", string subCurrency = "")
    {
        var wholePart = (int)number;
        var decimalPart = (int)Math.Round((number - wholePart) * 100);

        var wholeText = wholePart.ToWords(new CultureInfo("ar"));
        var decimalText = decimalPart > 0 ? decimalPart.ToWords(new CultureInfo("ar")) : "";

        var result = string.IsNullOrWhiteSpace(mainCurrency) ? wholeText : $"{wholeText} {mainCurrency}";

        if (decimalPart > 0)
        {
            result += string.IsNullOrWhiteSpace(subCurrency)
                ? $" فاصلة {decimalText}"
                : $" و {decimalText} {subCurrency}";
        }

        return result;
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
