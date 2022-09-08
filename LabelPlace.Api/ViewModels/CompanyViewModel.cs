using System.Collections.Generic;

namespace LabelPlace.Api.ViewModels
{
    public class CompanyViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public HashSet<ProjectViewModel> Projects { get; set; } = new HashSet<ProjectViewModel>();
    }
}
