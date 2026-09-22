using FluentValidation;
using OnlineShop.Areas.Admin.ViewModels;

namespace OnlineShop.Areas.Admin.Validators
{
    public class RoleViewModelValidator : AbstractValidator<RoleViewModel>
    {
        public RoleViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Role name not specified")
                .Length(2, 50).WithMessage("Role Name should from 2 to 50 symbols");
        }
    }
}
