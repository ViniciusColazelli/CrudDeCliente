using ClienteCRUD.Communication.Responses;

namespace ClienteCRUD.Application.UseCases.Produtos.GetProdutoDetalhe
{
    public interface IGetProdutoDetalheUseCase
    {
        Task<ResponseProdutoDetalhe> Execute(int id);
    }
}
