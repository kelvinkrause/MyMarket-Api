using Microsoft.Extensions.Configuration;

namespace MyMarket.Infrastructure.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetMyMarketConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("ConnectionSqlServer");
        }
    }
}
