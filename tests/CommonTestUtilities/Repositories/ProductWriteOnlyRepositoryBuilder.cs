using Moq;
using MyMarket.Domain.Repository.Product;

namespace CommonTestUtilities.Repositories
{
    public class ProductWriteOnlyRepositoryBuilder
    {
        public static IProductWriteOnlyRepository Build()
        {
            var mock = new Mock<IProductWriteOnlyRepository>();

            return mock.Object;
        }
    }
}
