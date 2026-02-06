using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Data.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyMarket.Infrastructure.Migrations
{
    public static class DatabaseMigration
    {
        public static void Migrations(string connetionString)
        {
            EnsureDatabaseCreated(connetionString);
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
