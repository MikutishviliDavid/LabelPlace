﻿using System.Collections.Generic;

namespace LabelPlace.Api.ViewModels.CompanyViewModels
{
    public class CreateCompanyRequest
    {
        //public int? Id { get; set; } // ?

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}