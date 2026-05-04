using ClienteCRUD.Domain.Repositories;
using ClienteCRUD.Domain.Security.Criptography;
using ClienteCRUD.Domain.Services.ClienteLogado;
using ClienteCRUD.Infrastructure.DataAcess;
using ClienteCRUD.Infrastructure.DataAcess.Repositories;
using ClienteCRUD.Infrastructure.Security.Criptography;
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
            SenhaCriptografada(services);
            AddDbContext_PostgreSql(services, configuration);
            AddRepositories(services);
            AddClienteLogado(services);
        }
        private static void AddDbContext_PostgreSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClienteCrudDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseNpgsql(configuration.GetConnectionString("ConnectionPostgreSql"));
            });
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
        private static void SenhaCriptografada(IServiceCollection services)
        {
            services.AddScoped<ISenhaCriptografada>(options => new Sha512Encripter());
        }
    }
}
