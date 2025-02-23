namespace ERP.Dtos.FormDto;
public record RequestFormDto(
    int PageNumber,
    int PageSize,
    string Search,
    string SortColumn,
    string Dir
);

