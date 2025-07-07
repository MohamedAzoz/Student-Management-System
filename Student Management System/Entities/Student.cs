using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Entities
{
    public class Student
    {
        public string SSN { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string College { get; set; } = null!;

        public string Department { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public override string ToString()
        {
            return $"SSN: {SSN} | Name: {Name} | DateOfBirth: {DateOfBirth} | " +
                $"College: {College} | Department: {Department}";
        }
    }
}
