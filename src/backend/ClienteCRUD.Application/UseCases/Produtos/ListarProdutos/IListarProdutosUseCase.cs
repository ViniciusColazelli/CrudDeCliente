using ClienteCRUD.Communication.Responses;

namespace ClienteCRUD.Application.UseCases.Produtos.ListarProdutos
{
    public interface IListarProdutosUseCase
    {
        Task<List<ResponseProduto>> Execute();
    }
}
