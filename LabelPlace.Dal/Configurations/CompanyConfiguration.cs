using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabelPlace.Dal.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasMany(c => c.Projects)
                .WithOne(p => p.Company)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.Country)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.City)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
