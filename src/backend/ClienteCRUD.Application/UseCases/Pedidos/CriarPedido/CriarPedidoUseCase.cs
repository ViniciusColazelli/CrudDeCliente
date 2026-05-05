using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;
using ClienteCRUD.Domain.Entities;
using ClienteCRUD.Domain.Repositories;
using ClienteCRUD.Domain.Services.ClienteLogado;
using ClienteCRUD.Exceptions;
using ClienteCRUD.Exceptions.ExceptionBase;
using System.Text.Json;

namespace ClienteCRUD.Application.UseCases.Pedidos.CriarPedido
{
    public class CriarPedidoUseCase : ICriarPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IClienteLogado _clienteLogado;
        private readonly ISalvarDB _salvarDB;

        public CriarPedidoUseCase(
            IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository,
            IClienteLogado clienteLogado,
            ISalvarDB salvarDB)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _clienteLogado = clienteLogado;
            _salvarDB = salvarDB;
        }

        public async Task<ResponsePedidoCriado> Execute(RequestCriarPedido request)
        {
            Validate(request);

            var cliente = await _clienteLogado.Cliente();

            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                Status = "pendente"
            };

            decimal total = 0;

            foreach (var itemRequest in request.Itens)
            {
                var produto = await _produtoRepository.GetPorId(itemRequest.ProdutoId)
                    ?? throw new NotFoundException(ResourceMensagensDeErro.PRODUTO_NAO_ENCONTRADO);

                var adicionais = produto.Opcoes
                    .Where(o => itemRequest.Customizacao.TryGetValue(o.Tipo, out var val) && val == o.Valor)
                    .Sum(o => o.PrecoAdicional);

                var precoUnitario = produto.PrecoBase + adicionais;

                var item = new PedidoItem
                {
                    ProdutoId = produto.Id,
                    Quantidade = itemRequest.Quantidade,
                    PrecoUnitario = precoUnitario,
                    CustomizacaoJson = JsonSerializer.Serialize(itemRequest.Customizacao),
                    LogoUrl = itemRequest.LogoUrl
                };

                pedido.Itens.Add(item);
                total += precoUnitario * itemRequest.Quantidade;
            }

            pedido.Total = total;

            await _pedidoRepository.Adicionar(pedido);
            await _salvarDB.Commit();

            return new ResponsePedidoCriado
            {
                Id = pedido.Id,
                Status = pedido.Status,
                Total = pedido.Total,
                CriadoEm = pedido.CriadoEm
            };
        }

        private void Validate(RequestCriarPedido request)
        {
            var validator = new CriarPedidoValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var mensagens = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErroEmValidacaoException(mensagens);
            }
        }
    }
}
