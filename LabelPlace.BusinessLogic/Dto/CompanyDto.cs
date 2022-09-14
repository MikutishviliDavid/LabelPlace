using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dto
{
    public class CompanyDto : BaseIntIdDto
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public HashSet<ProjectDto> Projects { get; set; } = new HashSet<ProjectDto>();
    }
}
