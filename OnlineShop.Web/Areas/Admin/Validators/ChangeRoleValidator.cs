using FluentValidation;
using OnlineShop.Areas.Admin.ViewModels;

namespace OnlineShop.Areas.Admin.Validators
{
    public class ChangeRoleValidator : AbstractValidator<ChangeRole>
    {
        public ChangeRoleValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Login not specified")
                .EmailAddress().WithMessage("Enter valid email")
                .Length(5, 30).WithMessage("Login should be from 5 to 30 symbols");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role not specified");
        }
    }
}
