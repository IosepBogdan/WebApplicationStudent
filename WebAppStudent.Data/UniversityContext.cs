using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppStudent.Data.Models;
using WebAppStundent.Models;

namespace WebAppStudent.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {

        }    
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=studentdb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var StudentCoursesModels = modelBuilder.Entity<StudentCourses>();
            modelBuilder.Entity<StudentCourses>().HasKey(x => new { x.StudentId, x.CourseId });
            modelBuilder.Entity<StudentCourses>().ToTable("StudentCourses");
            modelBuilder.Entity<StudentCourses>().Property(x => x.StudentId).HasColumnName("StudentId");
            modelBuilder.Entity<StudentCourses>().Property(x => x.CourseId).HasColumnName("CourseId");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }  
        public DbSet<StudentCourses> StudentCourses { get; set; }

    }
}
