using ContosoUniversity101.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContosoUniversity101.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    }
}
