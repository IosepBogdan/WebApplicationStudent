using WebAppStundent.Models;

namespace WebAppStudent.API.Services.Interfaces
{
    public interface ICourseService
    {
        Course GetCourse(int id);
        List<Course> GetAllCourses();
        void AddCourse(string course);
        bool UpdateCourse(int id, string Name);
        bool DeleteCourse(int id);
    }
}
