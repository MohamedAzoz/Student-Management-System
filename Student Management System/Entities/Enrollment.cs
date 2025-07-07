using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Entities
{
    public class Enrollment
    {
        public string Id { get; set; } = null!;
        public string CourseId { get; set; } = null!;
        public string StudentId { get; set; } = null!;
        public DateTime EnrollmentDate { get; set; }
        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;

        public Grade Grade { get; set; } = null!;

    }
}
