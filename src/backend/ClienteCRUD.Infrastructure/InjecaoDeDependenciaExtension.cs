using ClienteCRUD.Domain.Repositories;
using ClienteCRUD.Infrastructure.DataAcess;
using ClienteCRUD.Infrastructure.DataAcess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteCRUD.Infrastructure
{
    public static class InjecaoDeDependenciaExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {      
            AddDbContext_MySql(services);
            AddRepositories(services);
        }
        private static void AddDbContext_MySql(IServiceCollection services)
        {
            var connectionString = "ConnectionMysql";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 41));

            services.AddDbContext<ClienteCrudDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>(); // quando alguem solicitar um "IUserRepository" eu preciso devolver uma instancia do meu "UserRepository" dando um new no UserRepository
        }
    }
}
