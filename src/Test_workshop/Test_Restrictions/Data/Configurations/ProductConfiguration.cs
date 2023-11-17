using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_Restrictions.Models;

namespace Test_Restrictions.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Mobiles").HasKey(p => p.Ident);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
        }
    }
}
