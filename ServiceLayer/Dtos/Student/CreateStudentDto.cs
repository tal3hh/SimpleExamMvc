using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dtos.Student
{
    public class CreateStudentDto
    {
        public int Number { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int Grade { get; set; }
    }
}
