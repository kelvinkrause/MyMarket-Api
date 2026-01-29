using Microsoft.EntityFrameworkCore;
using MyMarket.Domain.Entities;

namespace MyMarket.Infrastructure.DataAccess
{
    public class MyMarketDbContext : DbContext
    {
        public MyMarketDbContext(DbContextOptions<MyMarketDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyMarketDbContext).Assembly);
        }

    }
}
