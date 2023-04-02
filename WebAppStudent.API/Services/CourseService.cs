using Microsoft.EntityFrameworkCore;
using WebAppStudent.API.Services.Interfaces;
using WebAppStudent.Data.Repository.UnitOfWork;
using WebAppStundent.Models;

namespace WebAppStudent.API.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddCourse(string courseName)
        {
            var course = new Course
            {
                CourseName = courseName
            };

            _unitOfWork.Courses.Add(course);
            _unitOfWork.SaveChanges();
        }

        public bool DeleteCourse(int id)
        {
            var Course = FindCourse(id);

            if (Course is null)
            {
                return false;
            }

            var entries = _unitOfWork.StudentCourse.GetQuery().Where(sc => sc.CourseId == id);

            _unitOfWork.StudentCourse.DeleteRange(entries);
            _unitOfWork.Courses.Delete(FindCourse(id));
            _unitOfWork.SaveChanges();

            return true;
        }

        public List<Course> GetAllCourses()
        {
            return _unitOfWork.Courses.GetQuery()
                .AsNoTracking()
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Student)
                .ToList();
        }

        public Course GetCourse(int id)
        {
            return FindCourse(id);
        }

        public bool UpdateCourse(int id, string Name)
        {
            var Course = FindCourse(id);

            if (Course is null)
            {
                return false;
            }

            Course.CourseName = Name;

            _unitOfWork.SaveChanges();

            return true;
        }
        private Course FindCourse(int id)
        {
            return _unitOfWork.Courses.GetById(id);
        }
    }
}
