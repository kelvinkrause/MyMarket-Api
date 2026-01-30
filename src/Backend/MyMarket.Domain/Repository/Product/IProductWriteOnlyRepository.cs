namespace MyMarket.Domain.Repository.Product
{
    public interface IProductWriteOnlyRepository
    {
        Task AddAsync(Entities.Product product);
    }
}
