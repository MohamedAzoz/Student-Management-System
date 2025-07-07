using Microsoft.EntityFrameworkCore;
using Student_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Data.Operitions
{
    public class UpdateData
    {
        public static void UpdateStudent(string studentId,Student student)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var existingStudent = context.Students.FirstOrDefault(s => s.SSN == studentId);
                    if (existingStudent == null)
                    {
                        Console.WriteLine($"Not found Student with SSN {studentId}");
                        return;
                    }
                    existingStudent.Name= student.Name;
                    existingStudent.College = student.College;
                    existingStudent.Department = student.Department;
                    existingStudent.DateOfBirth = student.DateOfBirth;

                    context.SaveChanges();
                    Console.WriteLine("✅ Student updated successfully.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding student: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }
        }

        public static void UpdateCourse(string courseId,Course course)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var existingCourse = context.Courses.FirstOrDefault(c => c.CourseCode == courseId);
                    if (existingCourse == null) {
                        Console.WriteLine($"Not found Course with name {course}");
                        return;
                    }
                    existingCourse.Name = course.Name;
                    existingCourse.Department = course.Department;
                    existingCourse.Number_of_hours = course.Number_of_hours;

                    context.SaveChanges();
                    Console.WriteLine("Course updated successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding course: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }
        }

        public static void UpdateGrade(string studentId, string course, double degree)
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
                            Console.WriteLine("No grade found for the enrollment.");
                            return;
                        }

                        enrollment.Grade.Value = degree;

                        context.SaveChanges();
                        transaction.Commit();
                        Console.WriteLine("✅ Grade updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ {ex}");
                        context.Database.RollbackTransaction();
                    }
                }
            }
        }

    }
}
