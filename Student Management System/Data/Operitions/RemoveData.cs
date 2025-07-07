using Microsoft.EntityFrameworkCore;
using Student_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Data.Operitions
{
    public class RemoveData
    {
        public static void RemoveStudent(string studentId)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var student = context.Students.FirstOrDefault(s => s.SSN == studentId);
                    if (student != null) 
                    context.Students.Remove(student);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding student: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }
        }

        public static void RemoveCourse(string courseId)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var course = context.Courses.FirstOrDefault(c => c.CourseCode == courseId);
                    if (course != null)
                    context.Courses.Remove(course);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding course: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }
        }

        public static void RemoveGrade(string studentId, string course)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var student = context.Students.FirstOrDefault(s => s.SSN == studentId);
                        var courseEntity = context.Courses.FirstOrDefault(c => c.Name == course);

                        if (student == null)
                        {
                            Console.WriteLine($"Not found Student with SSN {studentId}");
                            return;
                        }

                        if (courseEntity == null)
                        {
                            Console.WriteLine($"Not found Course with name {course}");
                            return;
                        }

                        var enrollment = context.Enrollments
                            .Include(e => e.Grade)
                            .FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseEntity.Id);

                        if (enrollment == null)
                        {
                            Console.WriteLine($"Not found Enrollment for Student with SSN {studentId} and Course {course}");
                            return;
                        }
                        if (enrollment.Grade == null)
                        {
                            Console.WriteLine("No grade to remove.");
                            return;
                        }

                        context.Grades.Remove(enrollment.Grade);
                        context.Enrollments.Remove(enrollment);

                        context.SaveChanges();

                        transaction.Commit();
                        Console.WriteLine("Grade Remove successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex}");
                        context.Database.RollbackTransaction();
                    }
                }
            }
        }

    }
}
