using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Domain.Extensions;
using ClienteCRUD.Domain.Repositories;
using ClienteCRUD.Domain.Services.ClienteLogado;
using ClienteCRUD.Exceptions;
using ClienteCRUD.Exceptions.ExceptionBase;

namespace ClienteCRUD.Application.UseCases.Update
{
    public class UpdateClienteUseCase : IUpdateClienteUseCase
    {
        private readonly IClienteLogado _clienteLogado;
        private readonly ISalvarDB _salvarDB;
        private readonly IUserRepository _userRepository;

        public UpdateClienteUseCase(IClienteLogado clienteLogado, ISalvarDB salvarDB, IUserRepository userRepository)
        {
            _clienteLogado = clienteLogado;
            _salvarDB = salvarDB;
            _userRepository = userRepository;
        }
        public async Task Execute(RequestUpdateCliente request)
        {
            var clienteLogado = await _clienteLogado.Cliente();

            await Validate(request, clienteLogado.Email);

            var user = await _userRepository.GetById(clienteLogado.Id);

            user.Nome = request.Nome;
            user.Email = request.Email;

            _userRepository.Update(user);

            await _salvarDB.Commit();
        }
        private async Task Validate(RequestUpdateCliente request, string currentEmail)
        {
            var validator = new UpdateClienteValidator();

            var result = validator.Validate(request);

            if (currentEmail.Equals(request.Email).IsFalse()) // esse isFalse é um metodo para indentificar se é falso no caso é o que a gente quer pra entrar no if.
            {
                var userExist = await _userRepository.ClienteAtivoComEmail(request.Email);
                if (userExist)
                    result.Errors.Add(new FluentValidation.Results.ValidationFailure("email", ResourceMensagensDeErro.EMAIL_JA_REGISTRADO));
            }
            if (result.IsValid.IsFalse())
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErroEmValidacaoException(errorMessages);
            }
        }
    }
}
