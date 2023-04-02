using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppStudent.Data.Models;
using WebAppStudent.Data.Repository.BaseRepository;
using WebAppStundent.Models;

namespace WebAppStudent.Data.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityContext _universityContext;
        public IRepository<Student> Students { get; set; }    
        public IRepository<Course> Courses { get; set; }
        public IRepository<StudentCourses> StudentCourse { get; set; }
        public UnitOfWork(UniversityContext universityContext)
        {
            _universityContext = universityContext;
            Students = new StudentRepository(_universityContext);
            Courses = new CourseRepository(_universityContext);
            StudentCourse = new StudentCourseRepository(_universityContext);
        }
        public void SaveChanges()
        {
            _universityContext.SaveChanges();
        }
        public void Dispose()
        {
            _universityContext.Dispose();
        }
    }
}
