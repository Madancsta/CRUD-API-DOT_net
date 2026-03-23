using Microsoft.EntityFrameworkCore;

namespace WorkShop3
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public  DbSet<Instructor> Instructors { get; set; }
        public DbSet<ModuleInstructor> ModuleInstructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
