using Humanizer;
using System.Globalization;

namespace ERP.Infrastructure.Services;
public class SD : ISD
{
    public string ConvertDecimalToWords(decimal number, string mainCurrency = "", string subCurrency = "")
    {
        string cultureInfo = CultureInfo.CurrentCulture.Name.StartsWith(ConstLanguage.Arabic) ? ConstLanguage.Arabic : ConstLanguage.English;
        bool isArabic = ((cultureInfo) is ConstLanguage.Arabic);

        var wholePart = (int)number;
        var decimalPart = (int)Math.Round((number - wholePart) * 100);

        var wholeText = wholePart.ToWords(new CultureInfo(cultureInfo));
        var decimalText = decimalPart > 0 ? decimalPart.ToWords(new CultureInfo(cultureInfo)) : "";

        var result = string.IsNullOrWhiteSpace(mainCurrency) ? wholeText : $"{wholeText} {mainCurrency}";

        if (decimalPart > 0)
            result += string.IsNullOrWhiteSpace(subCurrency)
                ? isArabic ? $" قرش {decimalText}" : $" penny {decimalText}"
                : isArabic ? $" و {decimalText} {subCurrency}" : $" and {decimalText} {subCurrency}";

        return result;
    }

}
