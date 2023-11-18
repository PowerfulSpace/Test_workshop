using Microsoft.EntityFrameworkCore;
using Test_Relationship.Models;

namespace Test_Relationship.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
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
            //modelBuilder.Entity<User>()
            //    .HasOne(p => p.Company)
            //    .WithMany(t => t.Users)
            //    .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
