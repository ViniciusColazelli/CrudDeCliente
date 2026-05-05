using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Exceptions;
using FluentValidation;

namespace ClienteCRUD.Application.UseCases.Pedidos.CalcularPreco
{
    public class CalcularPrecoValidator : AbstractValidator<RequestCalcularPreco>
    {
        public CalcularPrecoValidator()
        {
            RuleFor(r => r.ProdutoId)
                .GreaterThan(0)
                .WithMessage(ResourceMensagensDeErro.PRODUTO_INVALIDO);

            RuleFor(r => r.Customizacao)
                .NotEmpty()
                .WithMessage(ResourceMensagensDeErro.CUSTOMIZACAO_VAZIA);
        }
    }
}
