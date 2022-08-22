using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabelPlace.DAL.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasMany(c => c.Projects)
                .WithOne(p => p.Company);

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Country)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.City)
                .HasMaxLength(85)
                .IsRequired();
        }
    }
}
