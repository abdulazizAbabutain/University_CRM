namespace University_CRM.Application.Common.Models
{
    public class CollageDto 
    {
        public int Id { get; set; }
        public string NameArabic { get; set; } = string.Empty;
        public string NameEnglish { get; set; } = string.Empty;
        public string? DescriptionArabic { get; set; }
        public string? DescriptionEnglish { get; set; }
        public List<DepartmentDto> Departments { get; set; }
    }
}
