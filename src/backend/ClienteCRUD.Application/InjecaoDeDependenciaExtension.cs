using ClienteCRUD.Application.UseCases.Login;
using ClienteCRUD.Application.UseCases.Pedidos.CalcularPreco;
using ClienteCRUD.Application.UseCases.Pedidos.CriarPedido;
using ClienteCRUD.Application.UseCases.Pedidos.ListarPedidos;
using ClienteCRUD.Application.UseCases.Produtos.GetProdutoDetalhe;
using ClienteCRUD.Application.UseCases.Produtos.ListarProdutos;
using ClienteCRUD.Application.UseCases.Profile;
using ClienteCRUD.Application.UseCases.Registrar;
using ClienteCRUD.Application.UseCases.TrocarSenha;
using ClienteCRUD.Application.UseCases.Update;
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
            services.AddScoped<ILoginUsuarioUseCase, LoginUsuarioUseCase>(); // aqui é a mesma coisa, só que para o LoginUsuarioUseCase
            services.AddScoped<IGetClienteProfileUseCase, GetClienteProfileUseCase>();
            services.AddScoped<IUpdateClienteUseCase, UpdateClienteUseCase>();
            services.AddScoped<ITrocarSenhaUseCase, TrocarSenhaUseCase>();
            services.AddScoped<IListarProdutosUseCase, ListarProdutosUseCase>();
            services.AddScoped<IGetProdutoDetalheUseCase, GetProdutoDetalheUseCase>();
            services.AddScoped<ICalcularPrecoUseCase, CalcularPrecoUseCase>();
            services.AddScoped<ICriarPedidoUseCase, CriarPedidoUseCase>();
            services.AddScoped<IListarPedidosUseCase, ListarPedidosUseCase>();
        }
    }
}
