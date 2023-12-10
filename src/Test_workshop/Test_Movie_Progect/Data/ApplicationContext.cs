using Test_Movie_Progect.Models;
using Microsoft.EntityFrameworkCore;

namespace Test_Movie_Progect.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
    }
}
