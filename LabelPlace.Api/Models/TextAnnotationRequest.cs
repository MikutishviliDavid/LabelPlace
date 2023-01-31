using System;

namespace LabelPlace.Api.Models
{
    public class TextAnnotationRequest
    {
        public int ProjectId { get; set; }

        public string SourceText { get; set; }

        public string LabeledText { get; set; }
    }
}
