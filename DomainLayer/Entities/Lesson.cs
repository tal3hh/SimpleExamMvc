using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Lesson : BaseEntity
    {
        public string? Code { get; set; }
        public string? lessonName { get; set; }
        public int Grade { get; set; }
        public string? teacherName { get; set; }
        public string? teacherSurname { get; set; }

        public Exam? Exam { get; set; }
    }
}
