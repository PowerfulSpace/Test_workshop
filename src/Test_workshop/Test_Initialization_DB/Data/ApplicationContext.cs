using Microsoft.EntityFrameworkCore;
using Test_Initialization_DB.Models;

namespace Test_Initialization_DB.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Test_BaseProject_DB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
           new User[]
           {
                new User { Id=1, Name="Tom", Age=23},
                new User { Id=2, Name="Alice", Age=26},
                new User { Id=3, Name="Sam", Age=28}
           });
        }
    }
}
