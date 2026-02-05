namespace MyMarket.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
