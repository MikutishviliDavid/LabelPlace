using FluentValidation;
using LabelPlace.Api.ViewModels.CompanyViewModels;

namespace LabelPlace.Api.Validators
{
    public class CompanyValidator : AbstractValidator<CreateCompanyRequest>
    {
        public CompanyValidator()
        {
            RuleFor(m => m.Name).MaximumLength(64).NotEmpty();

            RuleFor(m => m.Country).MaximumLength(64).NotEmpty();

            RuleFor(m => m.City).MaximumLength(128).NotEmpty();
        }
    }
}