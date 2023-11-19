using Microsoft.EntityFrameworkCore;
using Test_Many_To_Many2.Models;


namespace Test_Many_To_Many2.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Test_BaseProject_DB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity<Enrollment>(
                   j => j
                    .HasOne(pt => pt.Student)
                    .WithMany(t => t.Enrollments)
                    .HasForeignKey(pt => pt.StudentId),
                j => j
                    .HasOne(pt => pt.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(pt => pt.CourseId),
                j =>
                {
                    j.Property(pt => pt.EnrollmentDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.Property(pt => pt.Mark).HasDefaultValue(3);
                    j.HasKey(t => new { t.CourseId, t.StudentId });
                    j.ToTable("Enrollments");
                });
        }

    }
}
