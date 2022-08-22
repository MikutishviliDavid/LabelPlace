using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabelPlace.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Projects)
                .WithOne(p => p.User);

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(320)
                .IsRequired();

            builder.Property(p => p.PasswordHash)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.PasswordSalt)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
