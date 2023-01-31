using FluentValidation;
using LabelPlace.Api.Models.CompanyModels;

namespace LabelPlace.Api.Validators
{
    public class GetAllByCountryRequestValidator : AbstractValidator<GetAllByCountryRequest>
    {
        public GetAllByCountryRequestValidator()
        {
            RuleFor(m => m.Country).MaximumLength(64).NotEmpty();
        }
    }
}
