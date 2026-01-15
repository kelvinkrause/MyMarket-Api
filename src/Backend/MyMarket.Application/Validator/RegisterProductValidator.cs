using FluentValidation;
using MyMarket.Communication.Requests;
using MyMarket.Exceptions.Resources;

namespace MyMarket.Application.Validator
{
    public class RegisterProductValidator : AbstractValidator<RequestRegisteredProductJson>
    {
        public RegisterProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage(ResourceMessageException.PRODUCT_NAME_REQUIRED)
                .MaximumLength(100).WithMessage(ResourceMessageException.PRODUCT_NAME_MAX_LENGTH);
            RuleFor(product => product.Description)
                .MaximumLength(500)
                .WithMessage(ResourceMessageException.PRODUCT_DESCRIPTION_MAX_LENGTH);
            RuleFor(product => product.Price)
                .GreaterThan(0)
                .WithMessage(ResourceMessageException.PRODUCT_PRICE_INVALID);
            RuleFor(product => product.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage(ResourceMessageException.PRODUCT_STOCK_QUANTITY_INVALID);
            RuleFor(product => product.Category)
                .NotEmpty().WithMessage(ResourceMessageException.PRODUCT_CATEGORY_REQUIRED);
            RuleFor(product => product.Barcode)
                .NotEmpty().WithMessage(ResourceMessageException.PRODUCT_BARCODE_REQUIRED)
                .Matches(@"^\d{12,13}$").WithMessage(ResourceMessageException.PRODUCT_BARCODE_INVALID_FORMAT);
        }
    }
}
