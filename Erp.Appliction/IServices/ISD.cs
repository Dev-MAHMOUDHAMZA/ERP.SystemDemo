

namespace Application.IServices;
public interface ISD
{
   string ConvertDecimalToWords(decimal number, string mainCurrency = "", string subCurrency = "");
}
