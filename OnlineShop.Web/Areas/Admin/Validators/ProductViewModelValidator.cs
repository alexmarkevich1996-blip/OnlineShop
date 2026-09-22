using FluentValidation;
using OnlineShop.Areas.Admin.ViewModels;

namespace OnlineShop.Areas.Admin.Validators
{
    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name not specified")
                .Length(2, 200).WithMessage("Name should be from 2 to 200");

            RuleFor(x => x.Cost)
                .InclusiveBetween(0, 1_000_000).WithMessage("Product cost should be from 0 to 1000000");

            RuleFor(x => x.Description)
                .MaximumLength(4096).WithMessage("Maximum length of product description");

            RuleFor(x => x.PhotoPath)
                .NotEmpty();
        }
    }
}
