namespace MyMarket.Domain.Repository.Product
{
    public interface IProductReadOnlyRepository
    {
        Task<Entities.Product?> GetByIdAsync(Guid id);
        Task<IEnumerable<Entities.Product>> GetAllAsync();
        Task<bool> ExistActiveProduct(Guid id);
    }
}
