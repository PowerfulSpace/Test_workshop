using Microsoft.EntityFrameworkCore;
using Test_EF.Models;

namespace Test_EF.Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Test_BaseProject_DB;Trusted_Connection=True;");
        }

        //Scaffold-DbContext "Server=(localdb)\\mssqllocaldb;Database=Test_BaseProject_DB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer

    }
}
