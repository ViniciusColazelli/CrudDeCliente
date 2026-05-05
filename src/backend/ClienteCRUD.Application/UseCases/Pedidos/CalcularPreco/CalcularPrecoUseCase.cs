using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;
using ClienteCRUD.Domain.Repositories;
using ClienteCRUD.Exceptions;
using ClienteCRUD.Exceptions.ExceptionBase;

namespace ClienteCRUD.Application.UseCases.Pedidos.CalcularPreco
{
    public class CalcularPrecoUseCase : ICalcularPrecoUseCase
    {
        private readonly IProdutoRepository _repository;

        public CalcularPrecoUseCase(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponsePrecoCalculado> Execute(RequestCalcularPreco request)
        {
            Validate(request);

            var todos = await _repository.ListarAtivos();
            Console.WriteLine($"Total produtos ativos: {todos.Count}");

            var produto = await _repository.GetPorId(request.ProdutoId)
                ?? throw new NotFoundException(ResourceMensagensDeErro.PRODUTO_NAO_ENCONTRADO);

            var totalAdicionais = produto.Opcoes
                .Where(o => request.Customizacao.TryGetValue(o.Tipo, out var val) && val == o.Valor)
                .Sum(o => o.PrecoAdicional);

            return new ResponsePrecoCalculado
            {
                PrecoBase = produto.PrecoBase,
                TotalAdicionais = totalAdicionais,
                Total = produto.PrecoBase + totalAdicionais
            };
        }

        private void Validate(RequestCalcularPreco request)
        {
            var validator = new CalcularPrecoValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var mensagens = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErroEmValidacaoException(mensagens);
            }
        }
    }

}
