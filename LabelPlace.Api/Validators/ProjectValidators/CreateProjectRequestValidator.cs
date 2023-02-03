using FluentValidation;
using LabelPlace.Api.Models.ProjectModels;

namespace LabelPlace.Api.Validators.ProjectValidators
{
    public class CreateProjectRequestValidator : AbstractValidator<CreateProjectRequest>
    {
        public CreateProjectRequestValidator()
        {
            RuleFor(m => m.UserId).NotEmpty();

            RuleFor(m => m.ComanyId).NotEmpty();

            RuleFor(m => m.Title).MaximumLength(256).NotEmpty();

            RuleFor(m => m.Description).MaximumLength(4096).NotEmpty();

            RuleFor(m => m.SourceDataUrl).MaximumLength(2048).NotEmpty();

            RuleFor(m => m.Status).NotNull().IsInEnum();

            RuleFor(m => m.Type).NotNull().IsInEnum();
        }
    }
}
