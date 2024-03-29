﻿using LabelPlace.Domain.Enums;
using System.Collections.Generic;

namespace LabelPlace.Domain.Entities
{
    public class Project : BaseIntId
    {
        public int UserId { get; set; }

        public int CompanyId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SourceDataUrl { get; set; }

        public ProjectStatus Status { get; set; }

        public ProjectType Type { get; set; }

        public User User { get; set; }

        public Company Company { get; set; }

        public HashSet<TextAnnotation> TextAnnotations { get; set; } = new HashSet<TextAnnotation>();
    }
}