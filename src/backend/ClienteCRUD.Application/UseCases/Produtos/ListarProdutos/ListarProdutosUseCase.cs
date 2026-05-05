using ClienteCRUD.Communication.Responses;
using ClienteCRUD.Domain.Repositories;

namespace ClienteCRUD.Application.UseCases.Produtos.ListarProdutos
{
    public class ListarProdutosUseCase : IListarProdutosUseCase
    {
        private readonly IProdutoRepository _repository;
        public ListarProdutosUseCase(IProdutoRepository repository) => _repository = repository;

        public async Task<List<ResponseProduto>> Execute()
        {
            var produtos = await _repository.ListarAtivos();
            return produtos.Select(p => new ResponseProduto
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                PrecoBase = p.PrecoBase
            }).ToList();
        }
    }
}
