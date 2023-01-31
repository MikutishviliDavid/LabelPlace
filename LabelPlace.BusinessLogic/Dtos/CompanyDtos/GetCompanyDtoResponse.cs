using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dtos.CompanyDtos
{
    public class GetCompanyDtoResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
