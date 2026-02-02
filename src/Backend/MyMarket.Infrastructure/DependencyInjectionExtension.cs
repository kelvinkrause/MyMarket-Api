using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMarket.Domain.Repository.Product;
using MyMarket.Infrastructure.DataAccess;
using MyMarket.Infrastructure.Extensions;
using MyMarket.Infrastructure.Repositories;

namespace MyMarket.Infrastructure
{
    public static class DependencyInjectionExtension
    {

        public static void AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetMyMarketConnectionString();
            services.AddDbContext<MyMarketDbContext>(options => 
                options.UseSqlServer(connectionString));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductReadOnlyRepository, ProductRepository>();
            services.AddScoped<IProductWriteOnlyRepository, ProductRepository>();
        }
    }
}
