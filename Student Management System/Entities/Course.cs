using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Entities
{
    public class Course
    {

        public string Id { get; set; }=null!;
        public string CourseCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Number_of_hours { get; set; }

        public string Department { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public override string ToString()
        {
            return $"Course Code: {CourseCode} | Name: {Name} | Number of hours: {Number_of_hours} | Department: {Department} ";
        }

    }
}
