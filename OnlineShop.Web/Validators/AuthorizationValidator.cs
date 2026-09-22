using FluentValidation;
using OnlineShop.ViewModels;

namespace OnlineShop.Validators
{
    public class AuthorizationValidator : AbstractValidator<Authorization>
    {
        public AuthorizationValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login not specified")
                .EmailAddress().WithMessage("Enter valid email")
                .Length(5, 30).WithMessage("The length should be from 5 to 30 symbols");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password not specified")
                .Length(6, 50).WithMessage("The length should be from 6 to 50 symbols");
        }
    }
}
