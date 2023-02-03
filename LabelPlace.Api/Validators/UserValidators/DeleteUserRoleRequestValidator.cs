using FluentValidation;
using LabelPlace.Api.Models.UserModels;

namespace LabelPlace.Api.Validators.UserValidators
{
    public class DeleteUserRoleRequestValidator : AbstractValidator<DeleteUserRoleRequest>
    {
        public DeleteUserRoleRequestValidator()
        {
            RuleFor(u => u.UserEmail).EmailAddress();

            RuleFor(u => u.Type).IsInEnum();
        }
    }
}
