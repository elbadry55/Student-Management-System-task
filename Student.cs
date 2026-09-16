using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System_task
{
    public class Student : Person
    {
        public int Age { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

        public Student(int id, string name, int age) : base(id, name)
        {
            Age = age;
        }

        public bool Enroll(Course course)
        {
            if (course == null) return false;
            bool isAlreadyEnrolled = Courses.Exists(c => c.CourseId == course.CourseId);
            if (isAlreadyEnrolled) return false;

            Courses.Add(course);
            return true;
        }

        public override string PrintDetails()
        {
            string details = $"[Student ID: {Id}] Name: {Name}, Age: {Age}\nEnrolled Courses:\n";

            if (Courses.Count == 0)
            {
                details += "  - No courses enrolled yet.\n";
            }
            else
            {
                foreach (var course in Courses)
                {
                    details += $"  - {course.Title} (Instructor: {course.Instructor?.Name ?? "None"})\n";
                }
            }

            return details;
        }
    }
}