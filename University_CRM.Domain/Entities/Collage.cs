using University_CRM.Domain.Common;

namespace University_CRM.Domain.Entities
{
    public class Collage : AuditEntity
    {
        public Collage()
        {
            Departments = new List<Department>();
        }
        
        public void UpdateNames(string nameArabic, string nameEnglish)
        {
            NameArabic= nameArabic;
            NameEnglish= nameEnglish;
        }
        public void UpdateDescriptions(string? descriptionArabic, string? descriptionEnglish)
        {
            DescriptionArabic = descriptionArabic;
            DescriptionEnglish = descriptionEnglish;
        }
        public int CollageId { get; set; }
        public string NameArabic { get; set; } = string.Empty;
        public string NameEnglish { get; set; } = string.Empty;
        public string? DescriptionArabic { get; set; }
        public string? DescriptionEnglish { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
