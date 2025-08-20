using ClienteCRUD.Communication.Responses;

namespace ClienteCRUD.Application.UseCases.Profile
{
    public interface IGetClienteProfileUseCase
    {
        public Task<ResponseClienteProfile> Execute();
    }
}
