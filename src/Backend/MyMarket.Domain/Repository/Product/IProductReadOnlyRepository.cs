namespace MyMarket.Domain.Repository.Product
{
    public interface IProductReadOnlyRepository
    {
        Task<Entities.Product?> GetByIdAsync(int id);
        Task<IEnumerable<Entities.Product>> GetAllAsync();
        Task<bool> ExistsActiveProduct(string barcode);
    }
}
