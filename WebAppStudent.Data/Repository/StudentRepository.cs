﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppStudent.Data.Repository.BaseRepository;
using WebAppStundent.Models;

namespace WebAppStudent.Data.Repository
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(UniversityContext universityContext) : base(universityContext) { }
        
    }
}
