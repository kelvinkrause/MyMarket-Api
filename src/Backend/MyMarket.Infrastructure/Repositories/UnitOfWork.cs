using MyMarket.Domain.Repositories;
using MyMarket.Infrastructure.DataAccess;

namespace MyMarket.Infrastructure.Repositories
{
    /// <summary>
    /// Implementa o padrão Unit of Work para gerenciar transações do banco de dados.
    /// Agrupa todas as alterações feitas nos repositórios e as salva de uma vez com CommitAsync().
    /// Usa o DbContext do Entity Framework para persistir os dados.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyMarketDbContext _context;

        public UnitOfWork(MyMarketDbContext context) => _context = context;
        public async Task CommitAsync() => await _context.SaveChangesAsync();
    }
}
