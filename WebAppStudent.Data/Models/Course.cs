using WebAppStudent.Data.Models;

namespace WebAppStundent.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
