using System;

namespace LabelPlace.Api.ViewModels
{
    public class TextAnnotationViewModel
    {
        public int ProjectId { get; set; }

        public string SourceText { get; set; }

        public string LabeledText { get; set; }

        public ProjectViewModel Project { get; set; }
    }
}
