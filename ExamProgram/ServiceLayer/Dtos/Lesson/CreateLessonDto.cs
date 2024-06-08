using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dtos.Lesson
{
    public class CreateLessonDto
    {
        public string? Code { get; set; }
        public string? lessonName { get; set; }
        public int Grade { get; set; }
        public string? teacherName { get; set; }
        public string? teacherSurname { get; set; }
    }
}
