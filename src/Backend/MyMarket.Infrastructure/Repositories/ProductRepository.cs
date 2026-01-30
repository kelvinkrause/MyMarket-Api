using MyMarket.Domain.Entities;
using MyMarket.Domain.Repository.Product;
using MyMarket.Infrastructure.DataAccess;

namespace MyMarket.Infrastructure.Repositories
{
    public class ProductRepository : IProductWriteOnlyRepository
    {
        private readonly MyMarketDbContext _context;
        public ProductRepository(MyMarketDbContext context) => _context = context;
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }
    }
}
