using ERP.Dtos.FormDto;

namespace ERP.Web.Extensions;
public static class FormCollection
{
    public static RequestFormDto GetRequestForm(this IFormCollection form)
    {
        return new RequestFormDto
        (
            PageNumber: int.Parse(form["start"]!),
            PageSize: int.Parse(form["length"]!),
            Dir: form["order[0][dir]"]!,
            SortColumn: form[string.Concat("columns[", form["order[0][column]"], "][data]")]!,
            Search: form["search[value]"]!
        );
    }
}
