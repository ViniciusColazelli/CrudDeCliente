using ClienteCRUD.Domain.Repositories;
using ClienteCRUD.Domain.Services.ClienteLogado;
using ClienteCRUD.Infrastructure.DataAcess;
using ClienteCRUD.Infrastructure.DataAcess.Repositories;
using ClienteCRUD.Infrastructure.Services.ClienteLogado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteCRUD.Infrastructure
{
    public static class InjecaoDeDependenciaExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {      
            AddDbContext_MySql(services, configuration);
            AddRepositories(services);
            AddClienteLogado(services);
        }
        private static void AddDbContext_MySql(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionMysql");  // aqui eu estou pegando a string de conexão do appsettings pelo configuration
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 41));

            services.AddDbContext<ClienteCrudDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ISalvarDB, SalvarDB>();

            services.AddScoped<IUserRepository, UserRepository>(); // quando alguem solicitar um "IUserRepository" eu preciso devolver uma instancia do meu "UserRepository" dando um new no UserRepository
        }
        private static void AddClienteLogado(IServiceCollection services)
        {
            services.AddScoped<IClienteLogado, ClienteLogado>();
        }
    }
}
