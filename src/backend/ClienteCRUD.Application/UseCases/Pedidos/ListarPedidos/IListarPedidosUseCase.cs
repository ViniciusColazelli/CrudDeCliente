using ClienteCRUD.Communication.Responses;

namespace ClienteCRUD.Application.UseCases.Pedidos.ListarPedidos
{
    public interface IListarPedidosUseCase
    {
        Task<List<ResponsePedido>> Execute();
    }
}
