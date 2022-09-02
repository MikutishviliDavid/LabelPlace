using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabelPlace.Domain.Entities
{
    public class TextAnnotation
    {
        public Guid Id { get; set; }

        public string SourceText { get; set; }

        public string LabeledText { get; set; }

        public Project Project { get; set; }
    }
}