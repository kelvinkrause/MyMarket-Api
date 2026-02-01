using Microsoft.EntityFrameworkCore;
using MyMarket.Domain.Entities;
using MyMarket.Domain.Repository.Product;
using MyMarket.Infrastructure.DataAccess;

namespace MyMarket.Infrastructure.Repositories
{
    public class ProductRepository : IProductWriteOnlyRepository, IProductReadOnlyRepository
    {
        private readonly MyMarketDbContext _context;
        public ProductRepository(MyMarketDbContext context) => _context = context;
        public async Task AddAsync(Product product) => 
            await _context.Products.AddAsync(product);

        public async Task<bool> ExistsActiveProduct(string barcode) => 
            await _context.Products.AnyAsync(prod => prod.Barcode.Equals(barcode) && prod.Active == true);

        public async Task<IEnumerable<Product>> GetAllAsync() => 
            await _context.Products.ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) => 
            await _context.Products.FindAsync(id);
    }
}
