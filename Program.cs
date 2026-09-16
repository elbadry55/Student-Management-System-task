using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            StudentManager manager = new StudentManager();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("     UNIVERSITY MANAGEMENT SYSTEM       ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find Student by ID or Name");
                Console.WriteLine("9. Find Course by ID or Title");
                Console.WriteLine("10. Check if Student Enrolled in Course (Bonus)");
                Console.WriteLine("11. Return Instructor Name by Course Name (Bonus)");
                Console.WriteLine("12. Exit");
                Console.WriteLine("========================================");
                Console.Write("Enter your choice (1-12): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("--- Add New Student ---");
                            Console.Write("Enter Student ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Age: ");
                            int age = int.Parse(Console.ReadLine());

                            Student newStudent = new Student(id, name, age);
                            bool added = manager.AddStudent(newStudent);

                            if (added)
                                Console.WriteLine("\nStudent added successfully!");
                            else
                                Console.WriteLine("\nError: Student ID already exists or invalid data.");
                            break;
                        }

                    case "2":
                        {
                            Console.WriteLine("--- Add New Instructor ---");
                            Console.Write("Enter Instructor ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Specialization: ");
                            string spec = Console.ReadLine();

                            Instructor newInstructor = new Instructor(id, name, spec);
                            bool added = manager.AddInstructor(newInstructor);

                            if (added)
                                Console.WriteLine("\nInstructor added successfully!");
                            else
                                Console.WriteLine("\nError: Instructor ID already exists.");
                            break;
                        }

                    case "3":
                        {
                            Console.WriteLine("--- Add New Course ---");
                            Console.Write("Enter Course ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Course Title: ");
                            string title = Console.ReadLine();

                            Console.Write("Enter Instructor ID for this course: ");
                            int instId = int.Parse(Console.ReadLine());

                            Instructor instructor = manager.FindInstructor(instId);
                            if (instructor == null)
                            {
                                Console.WriteLine("\nError: Instructor not found! Please add the instructor first.");
                                break;
                            }

                            Course newCourse = new Course(id, title, instructor);
                            bool added = manager.AddCourse(newCourse);

                            if (added)
                                Console.WriteLine("\nCourse added successfully!");
                            else
                                Console.WriteLine("\nError: Course ID already exists.");
                            break;
                        }

                    case "4":
                        {
                            Console.WriteLine("--- Enroll Student in Course ---");
                            Console.Write("Enter Student ID: ");
                            int sId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Course ID: ");
                            int cId = int.Parse(Console.ReadLine());

                            bool enrolled = manager.EnrollStudentInCourse(sId, cId);
                            if (enrolled)
                                Console.WriteLine("\nStudent enrolled in course successfully!");
                            else
                                Console.WriteLine("\nError: Enrollment failed (Check IDs or duplicate enrollment).");
                            break;
                        }

                    case "5":
                        {
                            Console.WriteLine("--- All Students ---");
                            if (manager.Students.Count == 0)
                            {
                                Console.WriteLine("No students found.");
                            }
                            else
                            {
                                foreach (var s in manager.Students)
                                {
                                    Console.WriteLine(s.PrintDetails());
                                    Console.WriteLine("----------------------------------------");
                                }
                            }
                            break;
                        }

                    case "6":
                        {
                            Console.WriteLine("--- All Courses ---");
                            if (manager.Courses.Count == 0)
                            {
                                Console.WriteLine("No courses found.");
                            }
                            else
                            {
                                foreach (var c in manager.Courses)
                                {
                                    Console.WriteLine(c.PrintDetails());
                                }
                            }
                            break;
                        }

                    case "7":
                        {
                            Console.WriteLine("--- All Instructors ---");
                            if (manager.Instructors.Count == 0)
                            {
                                Console.WriteLine("No instructors found.");
                            }
                            else
                            {
                                foreach (var i in manager.Instructors)
                                {
                                    Console.WriteLine(i.PrintDetails());
                                }
                            }
                            break;
                        }

                    case "8":
                        {
                            Console.WriteLine("--- Find Student ---");
                            Console.Write("Enter Student ID or Name: ");
                            string query = Console.ReadLine();
                            Student found = manager.FindStudent(query);

                            if (found != null)
                            {
                                Console.WriteLine("\nStudent Found:\n" + found.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("\nStudent not found.");
                            }
                            break;
                        }

                    case "9":
                        {
                            Console.WriteLine("--- Find Course ---");
                            Console.Write("Enter Course ID or Title: ");
                            string query = Console.ReadLine();
                            Course found = manager.FindCourse(query);

                            if (found != null)
                            {
                                Console.WriteLine("\nCourse Found:\n" + found.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("\nCourse not found.");
                            }
                            break;
                        }

                    case "10": 
                        {
                            Console.WriteLine("--- Check Student Enrollment ---");
                            Console.Write("Enter Student ID: ");
                            int sId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Course ID: ");
                            int cId = int.Parse(Console.ReadLine());

                            Student student = manager.FindStudent(sId);
                            Course course = manager.FindCourse(cId);

                            if (student != null && course != null)
                            {
                                bool isEnrolled = student.Courses.Exists(c => c.CourseId == cId);
                                if (isEnrolled)
                                    Console.WriteLine($"\nYes, student '{student.Name}' is enrolled in '{course.Title}'.");
                                else
                                    Console.WriteLine($"\nNo, student '{student.Name}' is NOT enrolled in '{course.Title}'.");
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid Student ID or Course ID.");
                            }
                            break;
                        }

                    case "11": 
                        {
                            Console.WriteLine("--- Find Instructor by Course Name ---");
                            Console.Write("Enter Course Title: ");
                            string courseTitle = Console.ReadLine();

                            Course course = manager.FindCourse(courseTitle);
                            if (course != null)
                            {
                                if (course.Instructor != null)
                                    Console.WriteLine($"\nThe instructor for '{course.Title}' is: {course.Instructor.Name} ({course.Instructor.Specialization})");
                                else
                                    Console.WriteLine("\nThis course has no assigned instructor.");
                            }
                            else
                            {
                                Console.WriteLine("\nCourse not found.");
                            }
                            break;
                        }

                    case "12":
                        exit = true;
                        Console.WriteLine("\nExiting application. Good bye ");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice! Please enter a number between 1 and 12.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
            }
    }   }
}
