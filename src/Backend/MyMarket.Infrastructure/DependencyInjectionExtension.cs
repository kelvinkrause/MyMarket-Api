using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMarket.Domain.Repositories;
using MyMarket.Domain.Repository.Product;
using MyMarket.Infrastructure.DataAccess;
using MyMarket.Infrastructure.Extensions;
using MyMarket.Infrastructure.Migrations;
using MyMarket.Infrastructure.Repositories;
using System.Reflection;

namespace MyMarket.Infrastructure
{
    public static class DependencyInjectionExtension
    {

        public static void AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddFluentMigratorToSQLServer(services, configuration);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetMyMarketConnectionString();
            services.AddDbContext<MyMarketDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductReadOnlyRepository, ProductRepository>();
            services.AddScoped<IProductWriteOnlyRepository, ProductRepository>();
        }

        private static void AddFluentMigratorToSQLServer(IServiceCollection services, IConfiguration configuration)
        {
            // Get the connection string from the configuration
            var connectionString = configuration.GetMyMarketConnectionString();
            // Add FluentMigrator services to the dependency injection container
            services.AddFluentMigratorCore()
                // Configure the runner to use SQL Server and specify the assembly containing the migrations
                .ConfigureRunner(options => options
                    // Add SQL Server support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string to use for the migrations
                    .WithGlobalConnectionString(connectionString)
                    // Define the assembly containing the migrations
                    .ScanIn(Assembly.Load("MyMarket.Infrastructure")).For.Migrations());
        }
    }
}
