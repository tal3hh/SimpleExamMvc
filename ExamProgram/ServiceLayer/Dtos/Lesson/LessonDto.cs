using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dtos.Lesson
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? lessonName { get; set; }
        public int Grade { get; set; }
        public string? teacherFullName { get; set; }
    }
}
