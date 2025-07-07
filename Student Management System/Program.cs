using Student_Management_System.Data.Operitions;

namespace Student_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            do
            {
            Console.WriteLine("Enter opration:\n" +
                " add\n" +
                " update\n" +
                " remove\n" +
                " show");
            string option = Console.ReadLine().ToLower();
                switch (option)
                {
                    case "add":
                        Console.WriteLine("Enter the type of data you want to add:\n" +
                            "1. Student\n" +
                            "2. Course\n" +
                            "3. Grade");
                        string dataType = Console.ReadLine().ToLower();
                        switch (dataType)
                        {
                            case "student":
                                Console.WriteLine("Enter Student SSN: ");
                                string ssn = Console.ReadLine();
                                Console.WriteLine("Enter Student Name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter Student College: ");
                                string college = Console.ReadLine();
                                Console.WriteLine("Enter Student Department: ");
                                string department = Console.ReadLine();
                                Console.WriteLine("Enter Student Date of Birth (yyyy-mm-dd): ");
                                AddData.AddStudent(new Entities.Student
                                {
                                    SSN = ssn,
                                    Name = name,
                                    College = college,
                                    Department = department,
                                    DateOfBirth = DateTime.Parse(Console.ReadLine())
                                });
                                break;
                            case "course":
                                Console.WriteLine("Enter Course Id: ");
                                string courseId = Console.ReadLine();

                                Console.WriteLine("Enter Course Code: ");
                                string courseCode = Console.ReadLine();

                                Console.WriteLine("Enter Course Name: ");
                                string courseName = Console.ReadLine();

                                Console.WriteLine("Enter Course Number of Hours: ");
                                int numberOfHours = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter Course Department: ");
                                string courseDepartment = Console.ReadLine();

                                AddData.AddCourse(new Entities.Course
                                {
                                    Id = courseId,
                                    CourseCode = courseCode,
                                    Name = courseName,
                                    Number_of_hours = numberOfHours,
                                    Department = courseDepartment
                                });
                                break;
                            case "grade":
                                Console.WriteLine("Enter Student SSN: ");
                                string SSN = Console.ReadLine();
                                Console.WriteLine("Enter Course Name: ");
                                string course = Console.ReadLine();
                                Console.WriteLine("Enter Id of Enrollment: ");
                                string enrollmentId = Console.ReadLine();

                                Console.WriteLine("Enter Grade Id: ");
                                int gradeId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Grade Value: ");
                                double gradeValue = double.Parse(Console.ReadLine());
                                AddData.AddGrade(SSN, course, enrollmentId, new Entities.Grade
                                {
                                    Id = gradeId,
                                    Value = gradeValue

                                });
                                break;
                            default:
                                Console.WriteLine($"Not Found this Option {dataType} ");
                                break;
                        }
                        break;

                    case "update" :
                        Console.WriteLine("Enter the type of data you want to update:\n" +
                            "1. Student\n" +
                            "2. Course\n" +
                            "3. Grade");
                        string updateType = Console.ReadLine().ToLower();
                        switch (updateType)
                        {
                            case "student":
                                Console.WriteLine("Enter Student SSN to update: ");
                                string ssnToUpdate = Console.ReadLine();
                                Console.WriteLine("Enter New Name: ");
                                string newName = Console.ReadLine();
                                Console.WriteLine("Enter New College: ");
                                string newCollege = Console.ReadLine();
                                Console.WriteLine("Enter New Department: ");
                                string newDepartment = Console.ReadLine();
                                Console.WriteLine("Enter New Date of Birth (yyyy-mm-dd): ");
                                UpdateData.UpdateStudent(ssnToUpdate, new Entities.Student
                                {
                                    SSN = ssnToUpdate,
                                    Name = newName,
                                    College = newCollege,
                                    Department = newDepartment,
                                    DateOfBirth = DateTime.Parse(Console.ReadLine())
                                });
                                break;
                            case "course":
                                Console.WriteLine("Enter Course Code to update: ");
                                string courseCodeToUpdate = Console.ReadLine();
                                Console.WriteLine("Enter New Course Name: ");
                                string newCourseName = Console.ReadLine();
                                Console.WriteLine("Enter New Course Department: ");
                                string newCourseDepartment = Console.ReadLine();
                                Console.WriteLine("Enter New Number of Hours: ");
                                int newNumberOfHours = int.Parse(Console.ReadLine());

                                UpdateData.UpdateCourse(courseCodeToUpdate, new Entities.Course
                                {
                                    CourseCode = courseCodeToUpdate,
                                    Name = newCourseName,
                                    Department = newCourseDepartment,
                                    Number_of_hours = newNumberOfHours
                                });
                            break;
                            case "grade":
                            Console.WriteLine("Enter Student SSN: ");
                            string ssnForGrade = Console.ReadLine();
                            Console.WriteLine("Enter Course Name: ");
                            string courseNameForGrade = Console.ReadLine();
                            Console.WriteLine("Enter New Grade Value: ");
                            double newGradeValue = double.Parse(Console.ReadLine());
                            UpdateData.UpdateGrade(ssnForGrade, courseNameForGrade, newGradeValue);
                            break;
                            default:
                            Console.WriteLine($"Not Found this Option {updateType} ");
                            break;
                        }
                        break;

                    case "remove":
                        Console.WriteLine("Enter the type of data you want to remove:\n" +
                        "1. Student\n" +
                        "2. Course\n" +
                        "3. Grade");
                    string removeType = Console.ReadLine().ToLower();
                    switch (removeType)
                    {
                        case "student":
                            Console.WriteLine("Enter Student SSN to remove: ");
                            string ssnToRemove = Console.ReadLine();
                            RemoveData.RemoveStudent(ssnToRemove);
                            break;
                        case "course":
                            Console.WriteLine("Enter Course Code to remove: ");
                            string courseCodeToRemove = Console.ReadLine();
                            RemoveData.RemoveCourse(courseCodeToRemove);
                            break;
                            case "grade":
                                Console.WriteLine("Enter Student SSN: ");
                                string ssnForGradeRemoval = Console.ReadLine();
                                Console.WriteLine("Enter Course Name: ");
                                string courseNameForGradeRemoval = Console.ReadLine();
                                RemoveData.RemoveGrade(ssnForGradeRemoval, courseNameForGradeRemoval);
                                break;
                            default:
                            Console.WriteLine($"Not Found this Option {removeType} ");
                            break;
                    }
                    break;

                    case "show":
                            Console.WriteLine("Enter the type of data you want to show:\n" +
                            "1. All Students\n" +
                            "2. Student by SSN\n" +
                            "3. Students in Same College\n" +
                            "4. Students in Same Department\n" +
                            "5. Course by Name");
                        string showType = Console.ReadLine().ToLower();
                        switch(showType) {
                            case "all students":
                                ShowData.ShowAllStudent();
                                break;
                            case "student by ssn":
                                Console.WriteLine("Enter Student SSN: ");
                                string ssnToShow = Console.ReadLine();
                                ShowData.ShowAllStudentData(ssnToShow);
                                break;
                            case "students in same college":
                                Console.WriteLine("Enter College Name: ");
                                string collegeName = Console.ReadLine();
                                ShowData.ShowAllStudentInSameCollege(collegeName);
                                break;
                            case "students in same department":
                                Console.WriteLine("Enter Department Name: ");
                                string departmentName = Console.ReadLine();
                                ShowData.ShowAllStudentInSameDepartment(departmentName);
                                break;
                            case "course by name":
                                Console.WriteLine("Enter Course Name: ");
                                string courseNameToShow = Console.ReadLine();
                                ShowData.ShowCourse(courseNameToShow);
                                break;
                            default:
                                Console.WriteLine($"Not Found this Option {showType} ");
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine($"Not Found this Option {option} ");
                        break;
                }
                Console.WriteLine("You want to continue Y | N ?");
                char reselt = char.Parse(Console.ReadLine());
                isRunning = (reselt == 'Y' || reselt == 'y') ? true : false;
            }
            while (isRunning);
            Console.WriteLine("Thank you for using the Student Management System. Goodbye!");

        }
    }
}
