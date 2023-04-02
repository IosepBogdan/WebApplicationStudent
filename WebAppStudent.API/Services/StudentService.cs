using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebAppStudent.API.Services.Interfaces;
using WebAppStudent.Data.Repository.UnitOfWork;
using WebAppStundent.Models;

namespace WebAppStudent.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddStudent(string studentName)
        {
            var student = new Student 
            { 
                StudentName = studentName 
            };

            _unitOfWork.Students.Add(student);
            _unitOfWork.SaveChanges();
        }

        public bool DeleteStudent(int id)
        {
            var Student = FindStudent(id);

            if (Student is null) 
            {
                return false;
            }

            var entries = _unitOfWork.StudentCourse.GetQuery().Where(sc => sc.StudentId == id);

            _unitOfWork.StudentCourse.DeleteRange(entries);
            _unitOfWork.Students.Delete(FindStudent(id));
            _unitOfWork.SaveChanges();

            return true;
        }

        public List<Student> GetAllStudents()
        {
            return _unitOfWork.Students.GetQuery()
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .ToList();
        }

        public Student GetStudent(int id)
        {
            return FindStudent(id);
        }

        public bool UpdateStudent(int id, string Name)
        {
            var Student = FindStudent(id);

            if (Student is null)
            {
                return false;
            }

            Student.StudentName = Name;

            _unitOfWork.SaveChanges();

            return true;
        }
        private Student FindStudent(int id)
        {
            return _unitOfWork.Students.GetById(id);
        }
    }
}
