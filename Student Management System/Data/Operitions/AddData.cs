using Microsoft.EntityFrameworkCore;
using Student_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Data.Operitions
{
    public class AddData
    {
        public static void AddStudent(Student student)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    Console.WriteLine("Student added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding student: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }
        }

        public static void AddCourse(Course course)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                    Console.WriteLine("Course added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding course: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }
        }

        public static void AddGrade(string studentId, string course,string Id, Grade grade)
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

                        context.Enrollments.Add(new Enrollment 
                        { 
                            Id=Id,
                            StudentId=studentId,
                            CourseId=courseEntity.Id,
                            EnrollmentDate= DateTime.Now,
                            Grade= grade
                        });

                      

                        //context.Grades.Add(grade);

                        context.SaveChanges();
                        transaction.Commit();
                        Console.WriteLine("Grade Add successfully.");
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
