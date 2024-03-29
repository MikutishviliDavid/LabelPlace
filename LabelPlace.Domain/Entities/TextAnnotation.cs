﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabelPlace.Domain.Entities
{
    public class TextAnnotation : BaseGuidId
    {
        public int ProjectId { get; set; }

        public string SourceText { get; set; }

        public string LabeledText { get; set; }

        public Project Project { get; set; }
    }
}