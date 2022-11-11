using LabelPlace.BusinessLogic.Dto.CompanyDtos;
using LabelPlace.BusinessLogic.Dto.UserDtos;
using LabelPlace.BusinessLogic.Enums;
using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dto
{
    public class ProjectDto
    {
        public int UserId { get; set; }

        public int CompanyId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SourceDataUrl { get; set; }

        public ProjectStatus Status { get; set; }

        public ProjectType Type { get; set; }

        public UserDto User { get; set; }

        public CreateCompanyDtoRequest Company { get; set; }

        public HashSet<TextAnnotationDto> TextAnnotations { get; set; } = new HashSet<TextAnnotationDto>();
    }
}
