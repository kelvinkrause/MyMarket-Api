using Dapper;
using FluentMigrator;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace MyMarket.Infrastructure.Migrations
{
    public static class DatabaseMigration
    {
        public static void Migrations(
            string connetionString,
            IServiceProvider serviceProvider)
        {
            EnsureDatabaseCreated(connetionString);
            MigrateDatabase(serviceProvider);
        }

        // This method is called after the application has started and the dependency injection
        // container has been built, so we can resolve the IMigrationRunner service from the container to run
        // the migrations.
        private static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            // Resolve the IMigrationRunner service from the dependency injection container to run the migrations.
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            // List all the migrations that are available in the assembly and have not been applied to the database yet.
            runner.ListMigrations();
            // Run the migrations to update the database schema to the latest version.
            // This will apply any pending migrations that have not been applied yet.
            runner.MigrateUp();
        }

        private static void EnsureDatabaseCreated(string connetionString)
        {
            var connectionStrigBuilder = new SqlConnectionStringBuilder(connetionString);
             
            var databaseName = connectionStrigBuilder.InitialCatalog;
            
            connectionStrigBuilder.Remove("Initial Catalog");

            using var dbConnection = new SqlConnection(connectionStrigBuilder.ConnectionString);

            var parameter = new DynamicParameters();

            parameter.Add("database", databaseName);

            var result = dbConnection.Query("SELECT * FROM SYS.DATABASES WHERE NAME = @database", parameter);

            if (!result.Any())
            {
                dbConnection.Execute($"CREATE DATABASE {databaseName}");
            }
        }
    }
}
