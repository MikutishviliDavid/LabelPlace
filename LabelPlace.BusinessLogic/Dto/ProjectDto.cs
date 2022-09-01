﻿using LabelPlace.BusinessLogic.Enums;
using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dto
{
    public class ProjectDto : BaseEntityDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string SourceDataUrl { get; set; }

        public ProjectStatus Status { get; set; }

        public ProjectType Type { get; set; }

        public UserDto User { get; set; }

        public CompanyDto Company { get; set; } // int CompanyId - ?

        public HashSet<TextAnnotationDto> TextAnnotations { get; set; } = new HashSet<TextAnnotationDto>();
    }
}
