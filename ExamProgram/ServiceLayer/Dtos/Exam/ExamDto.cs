using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dtos.Exam
{
    public class ExamDto
    {
        public int Id { get; set; }
        public DateTime examDate { get; set; }
        public int Score { get; set; }
        public string? Lesson { get; set; }
        public string? Student { get; set; }
    }
}
