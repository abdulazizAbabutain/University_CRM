namespace University_CRM.Domain.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string NameArabic { get; set; } = string.Empty;
        public string NameEnglish { get; set; } = string.Empty;
        public string? DescriptionArabic { get; set; }
        public string? DescriptionEnglish { get; set; }
        public int CollageId { get; set; }
        public Collage Collage { get; set; }
    }
}
