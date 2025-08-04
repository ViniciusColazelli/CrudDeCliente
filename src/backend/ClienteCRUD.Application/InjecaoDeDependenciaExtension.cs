using ClienteCRUD.Application.UseCases.Registrar;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteCRUD.Application
{
    public static class InjecaoDeDependenciaExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AdicionarUseCases(services);
        }

        private static void AdicionarUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>(); // essa é a parte que faria um new RegistrarUsuarioUseCase() mas é desse jeito que faz por injeção de dependencia. 
        }
    }
}
