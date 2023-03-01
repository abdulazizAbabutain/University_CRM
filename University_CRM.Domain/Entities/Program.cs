namespace University_CRM.Domain.Entities
{
    public class Program
    {
        public int ProgramId { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string DescriptionArabic { get; set; }
        public string DescriptionEnglsi { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public List<ProgramCourse> ProgramCourses { get; set; }
    }
}