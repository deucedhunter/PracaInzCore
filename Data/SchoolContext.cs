using Microsoft.EntityFrameworkCore;

namespace KimiNoGakko.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .ToTable("Person");

            modelBuilder.Entity<Student>()
                .ToTable("Student");

            modelBuilder.Entity<Instructor>()
                .ToTable("Instructor");
        }
    }
}
