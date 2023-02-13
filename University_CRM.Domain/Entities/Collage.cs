namespace University_CRM.Domain.Entities
{
    public class Collage
    {
        public Collage()
        {
            Departments = new List<Department>();
        }
        public int CollageId { get; set; }
        public string NameArabic { get; set; } = string.Empty;
        public string NameEnglish { get; set; } = string.Empty;
        public string? DescriptionArabic { get; set; }
        public string? DescriptionEnglish { get; set; }
        public List<Department> Departments { get; set; }
    }
}
