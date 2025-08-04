using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;

namespace ClienteCRUD.Application.UseCases.Registrar
{
    public interface IRegistrarUsuarioUseCase
    {
        public Task<ResponseUsuarioRegistrado> Execute(RequestRegistrarUsuario request);
    }
}
