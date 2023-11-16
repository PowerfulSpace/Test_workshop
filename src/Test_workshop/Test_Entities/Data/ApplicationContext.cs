using Microsoft.EntityFrameworkCore;
using Test_Entities.Models;

namespace Test_Entities.Data
{
    public class ApplicationContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Test_BaseProject_DB;Trusted_Connection=True;");
        }
    }
}
