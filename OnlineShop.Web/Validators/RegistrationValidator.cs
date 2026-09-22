using FluentValidation;
using OnlineShop.ViewModels;

namespace OnlineShop.Validators
{
    public class RegistrationValidator : AbstractValidator<Registration>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name not specified")
                .Length(2, 25).WithMessage("The length should be from 2 to 25 symbols");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname not specified")
                .Length(2, 25).WithMessage("The length should be from 2 to 25 symbols");

            RuleFor(x => x.Age)
                .InclusiveBetween(16, 100).WithMessage("Age should be from 16 to 100 years");

            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login not specified")
                .EmailAddress().WithMessage("Enter valid email");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone not specified");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password not specified")
                .NotEqual(x => x.Login).WithMessage("Login and password should not match");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Password Confirmation not specified")
                .Equal(x => x.Password).WithMessage("Passwords do not match");
        }
    }
}
