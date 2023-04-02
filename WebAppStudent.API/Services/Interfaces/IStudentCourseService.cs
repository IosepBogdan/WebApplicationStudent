namespace WebAppStudent.API.Services.Interfaces
{
    public interface IStudentCourseService
    {
        bool EnrollStudent(int StudentId, int CourseId);
        bool UnenrollStudent(int StudentId, int CourseId);
    }
}
