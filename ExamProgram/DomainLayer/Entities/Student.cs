using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Student : BaseEntity
    {
        public int Number { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int Grade { get; set; }

        public Exam? Exam { get; set; }
    }
}
