using MediatR;

namespace University_CRM.Application.Features.Departments.Commands;

public class FullUpdateDepartmentCommand : IRequest
{
    public int id { get; set; }
    public string NameArabic { get; set; } = string.Empty;
    public string NameEnglish { get; set; } = string.Empty;
    public string? DescriptionArabic { get; set; }
    public string? DescriptionEnglish { get; set; }
}
