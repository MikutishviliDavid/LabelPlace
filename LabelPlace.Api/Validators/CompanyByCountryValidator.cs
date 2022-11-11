using FluentValidation;
using LabelPlace.Api.ViewModels.CompanyViewModels;

namespace LabelPlace.Api.Validators
{
    public class CompanyByCountryValidator : AbstractValidator<CompanyByCountryViewModel>
    {
        public CompanyByCountryValidator()
        {
            RuleFor(m => m.Country).MaximumLength(64).NotEmpty();
        }
    }
}
