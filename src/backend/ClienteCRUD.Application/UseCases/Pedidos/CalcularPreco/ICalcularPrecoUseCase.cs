using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;

namespace ClienteCRUD.Application.UseCases.Pedidos.CalcularPreco
{
    public interface ICalcularPrecoUseCase
    {
        Task<ResponsePrecoCalculado> Execute(RequestCalcularPreco request);
    }
}
