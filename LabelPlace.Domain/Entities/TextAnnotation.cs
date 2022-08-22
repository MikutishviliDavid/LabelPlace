using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabelPlace.Domain.Entities
{
    public class TextAnnotation
    {
        public Guid Id { get; set; }

        public string SourceText { get; set; }

        [Column(TypeName = "json")]
        public string LabeledText { get; set; }

        public Project Project { get; set; }
    }
}