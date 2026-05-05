using ClienteCRUD.Communication.Responses;
using ClienteCRUD.Domain.Repositories;
using ClienteCRUD.Domain.Services.ClienteLogado;
using System.Text.Json;

namespace ClienteCRUD.Application.UseCases.Pedidos.ListarPedidos
{
    public class ListarPedidosUseCase : IListarPedidosUseCase
    {
        private readonly IPedidoRepository _repository;
        private readonly IClienteLogado _clienteLogado;

        public ListarPedidosUseCase(IPedidoRepository repository, IClienteLogado clienteLogado)
        {
            _repository = repository;
            _clienteLogado = clienteLogado;
        }

        public async Task<List<ResponsePedido>> Execute()
        {
            var cliente = await _clienteLogado.Cliente();
            var pedidos = await _repository.ListarPorCliente(cliente.Id);

            return pedidos.Select(p => new ResponsePedido
            {
                Id = p.Id,
                Status = p.Status,
                Total = p.Total,
                CriadoEm = p.CriadoEm,
                Itens = p.Itens.Select(i => new ResponsePedidoItem
                {
                    ProdutoNome = i.Produto.Nome,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario,
                    Customizacao = JsonSerializer.Deserialize<Dictionary<string, string>>(i.CustomizacaoJson) ?? [],
                    LogoUrl = i.LogoUrl
                }).ToList()
            }).ToList();
        }
    }
}
