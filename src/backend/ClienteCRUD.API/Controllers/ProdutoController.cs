using ClienteCRUD.Application.UseCases.Produtos.GetProdutoDetalhe;
using ClienteCRUD.Application.UseCases.Produtos.ListarProdutos;
using ClienteCRUD.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ClienteCRUD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        // GET /Produto
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseProduto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar([FromServices] IListarProdutosUseCase useCase)
        {
            var result = await useCase.Execute();
            return Ok(result);
        }

        // GET /Produto/{id}
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ResponseProdutoDetalhe), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Detalhe([FromServices] IGetProdutoDetalheUseCase useCase, int id)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }
    }
}
