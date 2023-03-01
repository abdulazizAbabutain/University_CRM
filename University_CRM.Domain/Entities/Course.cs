namespace University_CRM.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string NameArabic { get; set; } = string.Empty;
        public string NameEnglish { get; set; } = string.Empty;
        public string? DescriptionArabic { get; set; }
        public string? DescriptionEnglish { get; set; }
        public string CourseCode { get; set; }
        public int CreditHours { get; set; }
        public bool HasLap { get; set; }
        public ICollection<CoursePrerequisite> CoursePrerequisites { get; set; }
    }
}