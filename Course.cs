using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System_task
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor;
        }

        public string PrintDetails()
        {
            string instructorName = Instructor != null ? Instructor.Name : "Not Assigned";
            string specialization = Instructor != null ? Instructor.Specialization : "N/A";

            return $"[Course ID: {CourseId}] Title: {Title} | Instructor: {instructorName} ({specialization})";
        }
    }
}
