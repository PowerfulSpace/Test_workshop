using Microsoft.EntityFrameworkCore;
using Test_Restrictions.Models;

namespace Test_Restrictions.Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Company> Companies { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Modiles")
                .HasKey(x => x.Ident);

            modelBuilder.Entity<Product>()
                .Property(x => x.Name).IsRequired().HasMaxLength(30);

            modelBuilder.Entity<Company>().ToTable("Manufacturers")
               .Property(c => c.Name).IsRequired().HasMaxLength(30);
        }
    }
}
