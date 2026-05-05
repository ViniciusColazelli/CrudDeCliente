using ClienteCRUD.Application.UseCases.Pedidos.CalcularPreco;
using ClienteCRUD.Application.UseCases.Pedidos.CriarPedido;
using ClienteCRUD.Application.UseCases.Pedidos.ListarPedidos;
using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ClienteCRUD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        // POST /Pedido/calcular
        [HttpPost("calcular")]
        [ProducesResponseType(typeof(ResponsePrecoCalculado), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Calcular([FromServices] ICalcularPrecoUseCase useCase, [FromBody] RequestCalcularPreco request)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }

        // POST /Pedido
        [HttpPost]
        [ProducesResponseType(typeof(ResponsePedidoCriado), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Criar([FromServices] ICriarPedidoUseCase useCase, [FromBody] RequestCriarPedido request)
        {
            var result = await useCase.Execute(request);
            return Created(string.Empty, result);
        }

        // GET /Pedido
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponsePedido>), StatusCodes.Status200OK)]
        public async Task<IActionResult> MeusPedidos([FromServices] IListarPedidosUseCase useCase)
        {
            var result = await useCase.Execute();
            return Ok(result);
        }
    }
}
