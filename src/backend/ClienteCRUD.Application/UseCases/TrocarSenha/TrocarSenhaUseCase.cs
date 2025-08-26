using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Domain.Entities;
using ClienteCRUD.Domain.Extensions;
using ClienteCRUD.Domain.Repositories;
using ClienteCRUD.Domain.Security.Criptography;
using ClienteCRUD.Domain.Services.ClienteLogado;
using ClienteCRUD.Exceptions;
using ClienteCRUD.Exceptions.ExceptionBase;

namespace ClienteCRUD.Application.UseCases.TrocarSenha
{
    public class TrocarSenhaUseCase : ITrocarSenhaUseCase
    {
        private readonly IClienteLogado _clienteLogado;
        private readonly IUserRepository _repository;
        private readonly ISenhaCriptografada _senhaCriptografada;
        private readonly ISalvarDB _salvarDB;

        public TrocarSenhaUseCase(IClienteLogado clienteLogado, IUserRepository repository, ISenhaCriptografada senhaCriptografada, ISalvarDB salvarDB)
        {
            _clienteLogado = clienteLogado;
            _repository = repository;
            _senhaCriptografada = senhaCriptografada;
            _salvarDB = salvarDB;
        }

        public async Task Execute(RequestTrocarSenha request)
        {
            var clienteLogado = await _clienteLogado.Cliente();

            Validate(request, clienteLogado);

            var user = await _repository.GetById(clienteLogado.Id);

            user.Senha = _senhaCriptografada.Criptografia(request.NovaSenha);

            _repository.Update(user);

            await _salvarDB.Commit();
        }

        private void Validate(RequestTrocarSenha request, User clienteLogado)
        {
            var result = new TrocarSenhaValidator().Validate(request);

            var currentPasswordEncripted = _senhaCriptografada.Criptografia(request.Senha);

            if(currentPasswordEncripted.Equals(clienteLogado.Senha).IsFalse())
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMensagensDeErro.SENHA_ATUAL_NAO_REGISTRADA));

            if (result.IsValid.IsFalse())
                throw new ErroEmValidacaoException(result.Errors.Select(e => e.ErrorMessage).ToList());
        }
    }
}
