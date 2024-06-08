using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Exam : BaseEntity
    {
        public DateTime examDate { get; set; }
        public int Score { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }

        public Student? Student { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
