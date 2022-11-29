using FluentValidation;
using LabelPlace.Api.ViewModels.UserViewModels;
using System.Collections.Generic;

namespace LabelPlace.Api.Validators
{
    public class UserRegistrationValidator : AbstractValidator<UserViewModel> // rename to UserRegistrationViewModel
    {
        private const ViewModels.Enums.RoleType RoleType = default;

        public UserRegistrationValidator()
        {
            RuleFor(m => m.FirstName).MaximumLength(128).NotEmpty();

            RuleFor(m => m.LastName).MaximumLength(128).NotEmpty();

            RuleFor(m => m.Email).MaximumLength(512).NotEmpty().EmailAddress();//for email regex ?
        }
    }
}
