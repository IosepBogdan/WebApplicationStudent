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
    public interface IUnitOfWork
    {
        IRepository<Student> Students { get; }
        IRepository<Course> Courses { get; }
        IRepository<StudentCourses> StudentCourse { get; }
        void SaveChanges();
        void Dispose();
    }
}
