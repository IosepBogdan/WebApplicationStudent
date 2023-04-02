using WebAppStundent.Models;

namespace WebAppStudent.API.Services.Interfaces
{
    public interface IStudentService
    {
        Student GetStudent(int id);
        List<Student> GetAllStudents();
        void AddStudent(string student);
        bool UpdateStudent(int id, string Name);
        bool DeleteStudent(int id);
    }
}
