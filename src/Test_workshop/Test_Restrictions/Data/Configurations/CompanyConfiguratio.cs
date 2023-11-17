using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_Restrictions.Models;

namespace Test_Restrictions.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Manufacturers").Property(c => c.Name).IsRequired().HasMaxLength(30);
        }
    }
}
