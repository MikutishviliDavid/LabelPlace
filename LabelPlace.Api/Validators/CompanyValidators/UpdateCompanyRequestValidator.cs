using FluentValidation;
using LabelPlace.Api.Models.CompanyModels;

namespace LabelPlace.Api.Validators.CompanyValidators
{
    public class UpdateCompanyRequestValidator : AbstractValidator<UpdateCompanyRequest>
    {
        public UpdateCompanyRequestValidator()
        {
            RuleFor(m => m.Name).MaximumLength(64).NotEmpty();

            RuleFor(m => m.Country).MaximumLength(64).NotEmpty();

            RuleFor(m => m.City).MaximumLength(128).NotEmpty();
        }
    }
}
