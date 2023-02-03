using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dtos.CompanyDtos
{
    public class CreateCompanyDtoRequest
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
