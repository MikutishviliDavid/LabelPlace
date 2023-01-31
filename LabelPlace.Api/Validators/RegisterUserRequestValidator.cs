using FluentValidation;
using LabelPlace.Api.Models.Enums;
using LabelPlace.Api.Models.UserModels;
using System.Collections.Generic;

namespace LabelPlace.Api.Validators
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        private const RoleType RoleType = default;

        public RegisterUserRequestValidator()
        {
            RuleFor(u => u.FirstName).MaximumLength(128).NotEmpty();

            RuleFor(u => u.LastName).MaximumLength(128).NotEmpty();

            RuleFor(u => u.Email).EmailAddress();

            RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
            .MaximumLength(128).WithMessage("Password must be 128 characters or less.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one non-alphanumeric character.");

            RuleFor(u => u.PasswordConfirmation)
            .NotEmpty().WithMessage("Confirm password is required.")
            .Equal(u => u.Password).WithMessage("Passwords do not match.");
        }
    }
}
