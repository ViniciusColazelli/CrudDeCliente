using ClienteCRUD.Communication.Requests;

namespace ClienteCRUD.Application.UseCases.TrocarSenha
{
    public interface ITrocarSenhaUseCase
    {
        public Task Execute(RequestTrocarSenha request);
    }
}
