using WebAppStudent.API.Services.Interfaces;
using WebAppStudent.Data.Models;
using WebAppStudent.Data.Repository.UnitOfWork;

namespace WebAppStudent.API.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentCourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool EnrollStudent(int StudentId, int CourseId)
        {
            if (!_unitOfWork.Students.GetQuery().Any(s => s.StudentId == StudentId) ||
                !_unitOfWork.Courses.GetQuery().Any(c => c.CourseId == CourseId))
            {
                return false;
            }

            var StudentCourse = new StudentCourses
            {
                StudentId = StudentId,
                CourseId = CourseId
            };

            _unitOfWork.StudentCourse.Add(StudentCourse);
            _unitOfWork.SaveChanges();

            return true;
        }
        public bool UnenrollStudent(int StudentId, int CourseId)
        {
            if (_unitOfWork.Students.GetQuery().Any(s => s.StudentId == StudentId) ||
                _unitOfWork.Courses.GetQuery().Any(c => c.CourseId == CourseId))
            {
                return false;
            }

            var studentCourse = _unitOfWork.StudentCourse.GetQuery().Where(s => s.StudentId == StudentId && s.CourseId == CourseId).FirstOrDefault();
            
            if (studentCourse is null)
            {
                return false;
            }

            _unitOfWork.StudentCourse.Delete(studentCourse);
            _unitOfWork.SaveChanges();

            return true;
        }
    }
}
