using FluentValidation;
using OnlineShop.Core.Models;

namespace OnlineShop.Validators
{
    public class DeliveryUserValidator : AbstractValidator<DeliveryUser>
    {
        public DeliveryUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Buyer's name not specified")
                .Length(2, 25).WithMessage("Name should be from 2 to 25");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Delivery address not specified")
                .Length(5, 100).WithMessage("Delivery address should be from 5 to 100");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Buyer's phone not specified")
                .Matches(@"^[0-9+\-\s()]+$").WithMessage("Phone number should contain only digits")
                .Length(5, 16).WithMessage("Phone number should be from 5 to 16");

            RuleFor(x => x.Date)
                .Must(date =>
                {
                    var deliveryDate = DateOnly.FromDateTime(date);
                    var minDate = DateOnly.FromDateTime(DateTime.Now);
                    var maxDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(3));

                    return deliveryDate >= minDate && deliveryDate <= maxDate;
                })
                .WithMessage(_ =>
                {
                    var minDate = DateOnly.FromDateTime(DateTime.Now);
                    var maxDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(3));
                    return $"Date should be from {minDate.ToShortDateString()} to {maxDate.ToShortDateString()}";
                });

            RuleFor(x => x.Comment)
                .MaximumLength(512).WithMessage("Maximum length of the comment should not be over 512 symbols");
        }
    }
}
