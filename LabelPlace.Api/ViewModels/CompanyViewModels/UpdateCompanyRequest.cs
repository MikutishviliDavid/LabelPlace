namespace LabelPlace.Api.ViewModels.CompanyViewModels
{
    public class UpdateCompanyRequest
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
