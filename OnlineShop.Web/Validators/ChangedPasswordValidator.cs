using FluentValidation;
using OnlineShop.Core.DTO;

namespace OnlineShop.Validators
{
    public class ChangedPasswordValidator : AbstractValidator<ChangedPassword>
    {
        public ChangedPasswordValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login not specified")
                .EmailAddress().WithMessage("Enter valid email");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password not specified")
                .Length(6, 50).WithMessage("Password should be from 6 to 50 symbols")
                .NotEqual(x => x.Login).WithMessage("Login and password should not match");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Password Confirmation not specified")
                .Equal(x => x.Password).WithMessage("Passwords do not match");
        }
    }
}
