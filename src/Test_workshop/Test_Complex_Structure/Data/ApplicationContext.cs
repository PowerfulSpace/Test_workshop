using Microsoft.EntityFrameworkCore;
using Test_Complex_Structure.Models;

namespace Test_Complex_Structure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
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
    }
}
