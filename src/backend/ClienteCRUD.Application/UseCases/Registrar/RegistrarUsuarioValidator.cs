using ClienteCRUD.Communication.Requests;
using FluentValidation;

namespace ClienteCRUD.Application.UseCases.Registrar
{
    public class RegistrarUsuarioValidator : AbstractValidator<RequestRegistrarUsuario>
    {
        public RegistrarUsuarioValidator()
        {
            RuleFor(usuario => usuario.Nome).NotEmpty().WithMessage("O nome não pode ser vazio");
            RuleFor(usuario => usuario.CPF).NotEmpty().WithMessage("O CPF não pode ser vazio");
            RuleFor(usuario => usuario.CPF.Length).Equal(11).WithMessage("O CPF deve ter 11 digitos");
            RuleFor(usuario => usuario.Email).NotEmpty().WithMessage("O e-mail não pode ser vazio");
            RuleFor(usuario => usuario.Email).EmailAddress();
            RuleFor(usuario => usuario.Senha.Length).GreaterThan(6).WithMessage("A senha deve possuir mais de 6 caracteres");
            RuleFor(usuario => usuario.DataNascimento).NotEmpty().WithMessage("A data de nascimento não pode ser vazio");
        }
    }
}
