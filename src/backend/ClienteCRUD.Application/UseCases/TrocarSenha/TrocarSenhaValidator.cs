using ClienteCRUD.Application.SharedValidators;
using ClienteCRUD.Communication.Requests;
using FluentValidation;

namespace ClienteCRUD.Application.UseCases.TrocarSenha
{
    public class TrocarSenhaValidator : AbstractValidator<RequestTrocarSenha>
    {
        public TrocarSenhaValidator()
        {
            RuleFor(x => x.NovaSenha).SetValidator(new SenhaValidator<RequestTrocarSenha>());
        }
    }
}
