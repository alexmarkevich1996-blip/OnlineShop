using FluentValidation;
using OnlineShop.ViewModels;

namespace OnlineShop.Validators
{
    public class PlaceOrderValidator : AbstractValidator<PlaceOrder>
    {
        public PlaceOrderValidator()
        {
            RuleFor(x => x.DeliveryUser).SetValidator(new DeliveryUserValidator());
        }
    }
}
