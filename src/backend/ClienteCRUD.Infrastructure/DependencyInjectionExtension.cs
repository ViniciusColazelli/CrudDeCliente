using Microsoft.Extensions.DependencyInjection;

namespace ClienteCRUD.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {

        }
        private static void AddDbContext_MySql(IServiceCollection services)
        {
            var connectionString = "ConnectionMysql";
        }
    }
}
