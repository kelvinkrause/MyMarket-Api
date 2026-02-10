using Bogus;
using MyMarket.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterProductJsonBuilder
    {
        public static RequestRegisterProductJson Build()
        {
            return new Faker<RequestRegisterProductJson>()
                .RuleFor(product => product.Name, f => f.Commerce.ProductName())
                .RuleFor(product => product.Description, f => f.Commerce.ProductDescription())
                .RuleFor(prodcut => prodcut.Price, f => f.Random.Decimal(1, 1000))
                .RuleFor(product => product.StockQuantity, f => f.Random.Int(1, 100))
                .RuleFor(product => product.Category, f => f.Commerce.Categories(1)[0])
                .RuleFor(product => product.Barcode, f => f.Commerce.Ean13());
        }
    }
}
