﻿using Test_Movie_Progect.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test_Movie_Progect.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
               .HasMany(x => x.Genres)
               .WithMany(x => x.Movies);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(25);
        }
    }
}
