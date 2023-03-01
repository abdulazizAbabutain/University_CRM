using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_CRM.Domain.Entities
{
    public class CoursePrerequisite
    {
        public int CourseId { get; set; }
        public int CoursePrerequisiteId { get; set; }
        public Course Course { get; set; }
        public Course CoursePrerequisit { get; set; }
    }
}
