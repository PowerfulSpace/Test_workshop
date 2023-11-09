using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Test_workshop.MigrationFK.Models;

namespace Test_workshop.MigrationFK.Data
{
    public class InventoryContext : IdentityDbContext<IdentityUser>
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }

        public DbSet<Unit> Units { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
    }
}
