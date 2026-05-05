using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;

namespace ClienteCRUD.Application.UseCases.Pedidos.CriarPedido
{
    public interface ICriarPedidoUseCase
    {
        Task<ResponsePedidoCriado> Execute(RequestCriarPedido request);
    }
}
