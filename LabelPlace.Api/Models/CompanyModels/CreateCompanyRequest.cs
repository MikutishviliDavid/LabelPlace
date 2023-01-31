using System.Collections.Generic;

namespace LabelPlace.Api.Models.CompanyModels
{
    public class CreateCompanyRequest
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
