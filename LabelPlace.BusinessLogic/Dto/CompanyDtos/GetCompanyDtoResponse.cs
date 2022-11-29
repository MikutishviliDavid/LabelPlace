using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dto.CompanyDtos
{
    public class GetCompanyDtoResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public HashSet<ProjectDto> Projects { get; set; } = new HashSet<ProjectDto>();
    }
}
