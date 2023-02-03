using FluentValidation;
using LabelPlace.Api.Models.UserModels;

namespace LabelPlace.Api.Validators.UserValidators
{
    public class AddUserRoleRequestValidator : AbstractValidator<AddUserRoleRequest>
    {
        public AddUserRoleRequestValidator()
        {
            RuleFor(u => u.UserEmail).EmailAddress();

            RuleFor(u => u.Type).IsInEnum();
        }
    }
}
