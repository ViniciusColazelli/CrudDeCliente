using ClienteCRUD.Communication.Responses;
using ClienteCRUD.Domain.Repositories;
using ClienteCRUD.Exceptions;
using ClienteCRUD.Exceptions.ExceptionBase;

namespace ClienteCRUD.Application.UseCases.Produtos.GetProdutoDetalhe
{
    public class GetProdutoDetalheUseCase : IGetProdutoDetalheUseCase
    {
        private readonly IProdutoRepository _repository;
        public GetProdutoDetalheUseCase(IProdutoRepository repository) => _repository = repository;

        public async Task<ResponseProdutoDetalhe> Execute(int id)
        {
            var produto = await _repository.GetPorId(id)
                ?? throw new NotFoundException(ResourceMensagensDeErro.PRODUTO_NAO_ENCONTRADO);

            // Agrupa as opções por tipo: { "gola": ["V","Polo"], "cor": ["Azul","Preto"] }
            var opcoes = produto.Opcoes
                .GroupBy(o => o.Tipo)
                .Select(g => new ResponseGrupoOpcao
                {
                    Tipo = g.Key,
                    Itens = g.Select(o => new ResponseOpcaoItem
                    {
                        Valor = o.Valor,
                        PrecoAdicional = o.PrecoAdicional
                    }).ToList()
                }).ToList();

            return new ResponseProdutoDetalhe
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                PrecoBase = produto.PrecoBase,
                Opcoes = opcoes
            };
        }
    }
}
