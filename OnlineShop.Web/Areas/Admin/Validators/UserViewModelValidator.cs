using FluentValidation;
using OnlineShop.Areas.Admin.ViewModels;

namespace OnlineShop.Areas.Admin.Validators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login not specified")
                .EmailAddress().WithMessage("Enter valid email")
                .Length(5, 30).WithMessage("Login should be from 5 to 30 symbols");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name not specified")
                .Length(2, 25).WithMessage("Name should be from 2 to 25 symbols");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname not specified")
                .Length(2, 25).WithMessage("Surname should be from 2 to 25 symbols");

            RuleFor(x => x.Age)
                .InclusiveBetween(16, 100).WithMessage("Age should be from 16 to 100 years");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone not specified");
        }
    }
}
