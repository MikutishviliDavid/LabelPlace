using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabelPlace.DataAccess.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasMany(p => p.TextAnnotations)
                .WithOne(t => t.Project)
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(256)
                .IsRequired();
             
            builder.HasIndex(i => i.Title).IsUnique();

            builder.Property(p => p.Description).IsRequired();

            builder.Property(p => p.SourceDataUrl).IsRequired();

            builder.Property(p => p.Status).IsRequired();

            builder.HasIndex(i => i.Status).IsUnique();

            builder.Property(p => p.Type).IsRequired();
        }
    }
}
