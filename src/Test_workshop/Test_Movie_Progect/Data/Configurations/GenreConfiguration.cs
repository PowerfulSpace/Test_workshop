using Test_Movie_Progect.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test_Movie_Progect.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
              .HasMany(x => x.Movies)
              .WithMany(x => x.Genres);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
