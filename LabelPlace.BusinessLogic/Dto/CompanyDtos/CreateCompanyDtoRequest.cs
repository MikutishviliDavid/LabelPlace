﻿using System.Collections.Generic;

namespace LabelPlace.BusinessLogic.Dto.CompanyDtos
{
    public class CreateCompanyDtoRequest
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
