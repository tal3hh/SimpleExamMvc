using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dtos.Exam
{
    public class CreateExamDto
    {
        public DateTime examDate { get; set; }
        public int Score { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
    }
}
