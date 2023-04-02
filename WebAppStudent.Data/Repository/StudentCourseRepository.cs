using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppStudent.Data.Models;
using WebAppStudent.Data.Repository.BaseRepository;

namespace WebAppStudent.Data.Repository
{
    public class StudentCourseRepository : Repository<StudentCourses>
    {
        public StudentCourseRepository(UniversityContext universityContext) : base(universityContext) { }
    }
}
