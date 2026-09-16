using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System_task
{
    internal class StudentManager
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Instructor> Instructors { get; set; } = new List<Instructor>();

        public bool AddStudent(Student student)
        {
            if (student == null || Students.Any(s => s.Id == student.Id)) return false;
            Students.Add(student);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            if (instructor == null || Instructors.Any(i => i.Id == instructor.Id)) return false;
            Instructors.Add(instructor);
            return true;
        }

        public bool AddCourse(Course course)
        {
            if (course == null || Courses.Any(c => c.CourseId == course.CourseId)) return false;
            Courses.Add(course);
            return true;
        }

        public Student FindStudent(int id) => Students.FirstOrDefault(s => s.Id == id);
        public Course FindCourse(int id) => Courses.FirstOrDefault(c => c.CourseId == id);
        public Instructor FindInstructor(int id) => Instructors.FirstOrDefault(i => i.Id == id);

        public Student FindStudent(string nameOrId)
        {
            if (int.TryParse(nameOrId, out int id)) return FindStudent(id);
            return Students.FirstOrDefault(s => s.Name.Equals(nameOrId, StringComparison.OrdinalIgnoreCase));
        }

        public Course FindCourse(string titleOrId)
        {
            if (int.TryParse(titleOrId, out int id)) return FindCourse(id);
            return Courses.FirstOrDefault(c => c.Title.Equals(titleOrId, StringComparison.OrdinalIgnoreCase));
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            var student = FindStudent(studentId);
            var course = FindCourse(courseId);

            if (student == null || course == null) return false;
            return student.Enroll(course);
        }
    }
}
