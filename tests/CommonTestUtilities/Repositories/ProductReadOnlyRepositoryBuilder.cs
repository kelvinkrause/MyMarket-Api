using Moq;
using MyMarket.Domain.Repository.Product;

namespace CommonTestUtilities.Repositories
{
    public class ProductReadOnlyRepositoryBuilder
    {
        private readonly Mock<IProductReadOnlyRepository> _repository;

        public ProductReadOnlyRepositoryBuilder() => _repository = new Mock<IProductReadOnlyRepository>();
        
        public IProductReadOnlyRepository Build() => _repository.Object;
    }
}
