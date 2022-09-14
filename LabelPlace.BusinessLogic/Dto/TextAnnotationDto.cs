﻿using System;

namespace LabelPlace.BusinessLogic.Dto
{
    public class TextAnnotationDto : BaseGuidIdDto
    {
        public int ProjectId { get; set; }

        public string SourceText { get; set; }

        public string LabeledText { get; set; }

        public ProjectDto Project { get; set; }
    }
}