using LabelPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabelPlace.DataAccess.Configurations
{
    public class TextAnnotationConfiguration : IEntityTypeConfiguration<TextAnnotation>
    {
        public void Configure(EntityTypeBuilder<TextAnnotation> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.SourceText).IsRequired();

            builder.Property(p => p.LabeledText)
                .HasColumnType("jsonb")
                .IsRequired();
        }
    }
}
