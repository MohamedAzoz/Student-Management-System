using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public string EnrollmentId { get; set; } = null!;
        public double Value { get; set; }

        public Enrollment Enrollment { get; set; } = null!;
        public override string ToString()
        {
            return $"| Degree : {Value}";
        }
    }
}
