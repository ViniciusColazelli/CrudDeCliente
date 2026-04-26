using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;
using ClienteCRUD.Domain.Repositories;
using ClienteCRUD.Domain.Security.Criptography;
using ClienteCRUD.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Http;

namespace ClienteCRUD.Application.UseCases.Login
{
    public class LoginUsuarioUseCase : ILoginUsuarioUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ISenhaCriptografada _senhaCriptografada;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginUsuarioUseCase(IUserRepository userRepository,ISenhaCriptografada senhaCriptografada, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _senhaCriptografada = senhaCriptografada;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponseUsuarioRegistrado> Execute(RequestLoginUsuario request)
        {
            var senhaCriptografada = _senhaCriptografada.Criptografia(request.Senha);

            var user = await _userRepository.GetEmailAndPassword(request.Email, senhaCriptografada) ?? throw new ErroEmLoginException();// esses dois interrogativos são para verificar
                                                                                                                                        // caso seja nulo o metodo ou algum parametro do GetEmailAndPassword(),
            _httpContextAccessor.HttpContext!.Session.SetInt32("ClienteId", user.Id);                                                   // se for nulo, lança a exceção ErroEmLoginException se não, segue o fluxo

            return new ResponseUsuarioRegistrado()
            {
                Nome = user.Nome
            };
        }
    }
}
