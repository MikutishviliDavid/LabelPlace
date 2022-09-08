using FluentValidation;
using LabelPlace.Api.ViewModels;

namespace LabelPlace.Api.Validators
{
    public class ProjectValidator : AbstractValidator<ProjectViewModel>
    {
        public ProjectValidator()
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
