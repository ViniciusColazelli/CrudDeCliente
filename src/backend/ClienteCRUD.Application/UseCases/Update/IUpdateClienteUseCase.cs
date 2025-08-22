using ClienteCRUD.Communication.Requests;

namespace ClienteCRUD.Application.UseCases.Update
{
    public interface IUpdateClienteUseCase
    {
        public Task Execute(RequestUpdateCliente request);
    }
}
