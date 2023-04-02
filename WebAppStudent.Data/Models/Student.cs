using System.Diagnostics;
using WebAppStudent.Data.Models;

namespace WebAppStundent.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
        
    }
}
