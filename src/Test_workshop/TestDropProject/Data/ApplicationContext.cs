using Microsoft.EntityFrameworkCore;
using TestDropProject.Models;

namespace TestDropProject.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public virtual DbSet<Country> Countries { get; set; }
    }
}
