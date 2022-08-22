using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabelPlace.DAL.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(r => r.Users)
                .WithMany(u => u.Roles)
                .UsingEntity(j => j.ToTable("UserRoles"));

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Description).IsRequired();

            builder.Property(p => p.Type).IsRequired();
        }
    }
}
