using ClienteCRUD.Application.SharedValidators;
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
            RuleFor(usuario => usuario.Email).NotEmpty().WithMessage(ResourceMensagensDeErro.EMAIL_VAZIO);
            RuleFor(usuario => usuario.Email).EmailAddress().WithMessage(ResourceMensagensDeErro.EMAIL_INVALIDO);
            RuleFor(usuario => usuario.Senha).SetValidator(new SenhaValidator<RequestRegistrarUsuario>());
        }
    }
}
