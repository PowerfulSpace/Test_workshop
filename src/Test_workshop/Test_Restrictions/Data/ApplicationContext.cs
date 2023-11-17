using Microsoft.EntityFrameworkCore;
using Test_Restrictions.Models;

namespace Test_Restrictions.Data
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
            modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();
        }
    }
}
