using ClienteCRUD.Application.Services.Criptografia;
using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;
using ClienteCRUD.Domain.Repositories;
using ClienteCRUD.Exceptions.ExceptionBase;

namespace ClienteCRUD.Application.UseCases.Login
{
    public class LoginUsuarioUseCase : ILoginUsuarioUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly SenhaCriptografada _senhaCriptografada;

        public LoginUsuarioUseCase(IUserRepository userRepository,SenhaCriptografada senhaCriptografada)
        {
            _userRepository = userRepository;
            _senhaCriptografada = senhaCriptografada;
        }
        public async Task<ResponseUsuarioRegistrado> Execute(RequestLoginUsuario request)
        {
            var senhaCriptografada = _senhaCriptografada.Criptografia(request.Senha);

            var user = await _userRepository.GetEmailAndPassword(request.Email, senhaCriptografada) ?? throw new ErroEmLoginException();

            return new ResponseUsuarioRegistrado()
            {
                Nome = user.Nome
            };
        }
    }
}
