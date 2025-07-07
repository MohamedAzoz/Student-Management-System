using Microsoft.EntityFrameworkCore;
using Student_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System.Data.Operitions
{
    public class ShowData
    {
        public static void ShowStudent(string studentId)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var student = context.Students.FirstOrDefault(x=>x.SSN==studentId);
                    if (student != null)
                    {
                        Console.WriteLine(student);
                    }
                    else
                    {
                        Console.WriteLine($"not found Student with SSN {studentId}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding student: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }
        }
        public static void ShowCourse(string course)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var courseData = context.Courses.FirstOrDefault(x=>x.Name== course);
                    var enrollments=context.Enrollments
                        .Where(x=>x.Course== courseData)
                        .Include(s=>s.Student)
                        .ToList();
                    if (courseData != null)
                    {
                        Console.WriteLine(courseData);
                        foreach (var item in enrollments.Select(x=>x.Student))
                        {
                              
                            Console.WriteLine(item);
                        
                        }
                    }
                    else
                    {
                        Console.WriteLine($"not found course with Name {course}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding student: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }
        }
        public static void ShowAllStudentData(string studentId)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    /*
                    var studentWithEnrollments = context.Students
                            .Where(s => s.SSN == studentId)
                            .Include(s => s.Enrollments)
                                .ThenInclude(e => e.Course)
                            .Include(s => s.Enrollments)
                                .ThenInclude(e => e.Grade)
                            .FirstOrDefault();

                    if (studentWithEnrollments == null)
                    {
                        Console.WriteLine("الطالب غير موجود.");
                    }
                    else
                    {
                        Console.WriteLine($"{studentWithEnrollments}");
                        foreach (var item in studentWithEnrollments.Enrollments.OrderBy(e => e.Course.CourseCode))
                        {
                            Console.WriteLine($"{item.Course} {item.Grade}");
                        }
                    }*/

                    var student = context.Students
                        .FirstOrDefault(x => x.SSN == studentId);
                    var enrollments = context.Enrollments
                        .Where(x => x.StudentId == studentId)
                        .Include(x => x.Course)
                        .Include(x => x.Grade)
                        .OrderBy(x => x.Course.CourseCode)
                        .ToList();

                    if (student == null)
                    {
                        Console.WriteLine($"not found student with SSN {studentId}");
                    }
                    else
                    {
                        Console.WriteLine($"{student}");
                        foreach (var item in enrollments)
                        {
                            Console.WriteLine($"{item.Course} {item.Grade}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding student: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }
        }
        public static void ShowAllStudent()
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var students = context.Students.GroupBy(x=>x.College).ToList();
                    foreach (var item in students)
                    {
                        Console.WriteLine($"\nCollege: {item.Key}\n");
                        foreach (var item1 in item)
                        { 
                            Console.WriteLine(item1);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding grade: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }
        }
        public static void ShowAllStudentInSameCollege(string college)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var students = context.Students.Where(x => x.College == college).ToList();
                    foreach (var item in students)
                    {

                        Console.WriteLine(item);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding grade: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }
        }
        public static void ShowAllStudentInSameDepartment(string department)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    var students = context.Students.Where(x => x.Department == department).ToList();
                    foreach (var item in students)
                    {

                        Console.WriteLine(item);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding grade: {ex.Message}");
                    context.Database.RollbackTransaction();
                }
            }

        }
    }
}
