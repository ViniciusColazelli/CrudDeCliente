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

            var user = await _userRepository.GetEmailAndPassword(request.Email, senhaCriptografada) ?? throw new ErroEmLoginException();// esses dois interrogativos são para verificar
                                                                                                                                   // caso seja nulo o metodo ou algum parametro do GetEmailAndPassword(),
                                                                                                                                // se for nulo, lança a exceção ErroEmLoginException se não, segue o fluxo
            return new ResponseUsuarioRegistrado()
            {
                Nome = user.Nome
            };
        }
    }
}
