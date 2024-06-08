using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Dtos.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string? fullName { get; set; }
        public int Grade { get; set; }
    }
}
