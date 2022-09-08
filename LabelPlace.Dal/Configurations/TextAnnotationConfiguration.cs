using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabelPlace.Dal.Configurations
{
    public class TextAnnotationConfiguration : IEntityTypeConfiguration<TextAnnotation>
    {
        public void Configure(EntityTypeBuilder<TextAnnotation> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(t => t.Project)
                .WithMany(p => p.TextAnnotations)
                .HasForeignKey(t => t.ProjectId)
                .IsRequired();

            builder.Property(p => p.SourceText).IsRequired();

            builder.Property(p => p.LabeledText)
                .HasColumnType("jsonb");
        }
    }
}
