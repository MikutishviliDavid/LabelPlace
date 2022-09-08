using FluentValidation;
using LabelPlace.Api.ViewModels;

namespace LabelPlace.Api.Validators
{
    public class CompanyValidator : AbstractValidator<CompanyViewModel>
    {
        public CompanyValidator()
        {
            RuleFor(m => m.Name).MaximumLength(64).NotEmpty();

            RuleFor(m => m.Country).MaximumLength(64).NotEmpty();

            RuleFor(m => m.City).MaximumLength(128).NotEmpty();
        }
    }
}