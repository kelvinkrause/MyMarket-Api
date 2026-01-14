using FluentValidation;
using MyMarket.Communication.Requests;

namespace MyMarket.Application.Validator
{
    public class RegisterProductValidator : AbstractValidator<RequestRegisteredProductJson>
    {
        public RegisterProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");
            RuleFor(product => product.Description)
                .MaximumLength(500)
                .WithMessage("Product description must not exceed 500 characters.");
            RuleFor(product => product.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");
            RuleFor(product => product.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Stock quantity cannot be negative.");
            RuleFor(product => product.Category)
                .NotEmpty().WithMessage("Product category is required.");
            RuleFor(product => product.Barcode)
                .NotEmpty().WithMessage("Product barcode is required.")
                .Matches(@"^\d{12,13}$").WithMessage("Barcode must be 12 or 13 digits.");
        }
    }
}
