using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;

namespace ClienteCRUD.Application.UseCases.Login
{
    public interface ILoginUsuarioUseCase
    {
        public Task<ResponseUsuarioRegistrado> Execute(RequestLoginUsuario request);
    }
}
