using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Exceptions;
using FluentValidation;

namespace ClienteCRUD.Application.UseCases.Registrar
{
    public class RegistrarUsuarioValidator : AbstractValidator<RequestRegistrarUsuario>
    {
        public RegistrarUsuarioValidator()
        {
            RuleFor(usuario => usuario.Nome).NotEmpty().WithMessage(ResourceMensagensDeErro.NOME_VAZIO);
            RuleFor(usuario => usuario.CPF).NotEmpty().WithMessage(ResourceMensagensDeErro.CPF_VAZIO);
            RuleFor(usuario => usuario.CPF.Length).Equal(11).WithMessage(ResourceMensagensDeErro.CPF_INVALIDO);
            RuleFor(usuario => usuario.Email).NotEmpty().WithMessage(ResourceMensagensDeErro.EMAIL_VAZIO);
            RuleFor(usuario => usuario.Email).EmailAddress().WithMessage(ResourceMensagensDeErro.EMAIL_INVALIDO);
            RuleFor(usuario => usuario.Senha).NotEmpty().WithMessage(ResourceMensagensDeErro.SENHA_VAZIA);
            RuleFor(usuario => usuario.Senha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMensagensDeErro.SENHA_INVALIDA);
        }
    }
}
