using ClienteCRUD.Application.Services.Criptografia;
using ClienteCRUD.Application.UseCases.Login;
using ClienteCRUD.Application.UseCases.Profile;
using ClienteCRUD.Application.UseCases.Registrar;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteCRUD.Application
{
    public static class InjecaoDeDependenciaExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AdicionarUseCases(services);
            SenhaCriptografada(services);
        }

        private static void AdicionarUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>(); // essa é a parte que faria um new RegistrarUsuarioUseCase() mas é desse jeito que faz por injeção de dependencia. 
            services.AddScoped<ILoginUsuarioUseCase, LoginUsuarioUseCase>(); // aqui é a mesma coisa, só que para o LoginUsuarioUseCase
            //services.AddScoped<IGetClienteProfileUseCase, GetClienteProfileUseCase>();
        }

        private static void SenhaCriptografada(IServiceCollection services)
        {
            services.AddScoped(options => new SenhaCriptografada());
        }
    }
}
