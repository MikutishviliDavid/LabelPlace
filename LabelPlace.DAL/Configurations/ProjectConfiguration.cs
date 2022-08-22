using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabelPlace.DAL.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasMany(p => p.TextAnnotations)
                .WithOne(t => t.Project);

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title)
                .HasMaxLength(255)
                .IsRequired();
             
            builder.HasIndex(i => i.Title).IsUnique();

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.SourceDataUrl)
                .HasMaxLength(2048)
                .IsRequired();

            builder.Property(p => p.Status).IsRequired();

            builder.HasIndex(i => i.Status).IsUnique();

            builder.Property(p => p.Type).IsRequired();
        }
    }
}
