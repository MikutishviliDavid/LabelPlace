using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabelPlace.Dal.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasMany(u => u.Projects)
                .WithOne(p => p.User)
                .IsRequired();

            builder.Property(p => p.FirstName)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(512)
                .IsRequired();

            builder.HasIndex(i => i.Email).IsUnique();

            builder.Property(p => p.PasswordHash)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.PasswordSalt)
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
