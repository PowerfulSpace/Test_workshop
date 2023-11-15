using Microsoft.EntityFrameworkCore;
using Test_scheme.Models;

namespace Test_scheme.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test_BaseProject_DB;Trusted_Connection=True;");
        }

    }
}
