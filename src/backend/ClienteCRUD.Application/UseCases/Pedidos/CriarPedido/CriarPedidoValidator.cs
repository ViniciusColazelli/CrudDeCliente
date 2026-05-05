using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Exceptions;
using FluentValidation;

namespace ClienteCRUD.Application.UseCases.Pedidos.CriarPedido
{
    public class CriarPedidoValidator : AbstractValidator<RequestCriarPedido>
    {
        public CriarPedidoValidator()
        {
            RuleFor(p => p.Itens)
                .NotEmpty()
                .WithMessage(ResourceMensagensDeErro.PEDIDO_SEM_ITENS);

            RuleForEach(p => p.Itens).ChildRules(item =>
            {
                item.RuleFor(i => i.ProdutoId)
                    .GreaterThan(0)
                    .WithMessage(ResourceMensagensDeErro.PRODUTO_INVALIDO);

                item.RuleFor(i => i.Quantidade)
                    .GreaterThan(0)
                    .WithMessage(ResourceMensagensDeErro.QUANTIDADE_INVALIDA);

                item.RuleFor(i => i.Customizacao)
                    .NotEmpty()
                    .WithMessage(ResourceMensagensDeErro.CUSTOMIZACAO_VAZIA);
            });
        }
    }
}
