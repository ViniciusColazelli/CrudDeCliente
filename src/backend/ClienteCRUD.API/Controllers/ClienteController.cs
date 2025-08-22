using ClienteCRUD.Application.UseCases.Profile;
using ClienteCRUD.Application.UseCases.Registrar;
using ClienteCRUD.Application.UseCases.Update;
using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ClienteCRUD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUsuarioRegistrado), StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromServices]IRegistrarUsuarioUseCase useCase, [FromBody]RequestRegistrarUsuario request)
        {
        //  var useCase = new RegistrarUsuarioUseCase(); <- para não usar dessa forma o useCase dando um new vamos utilizar por injeção de dependencia
        //  que no caso vou ter que passar como parametro no metodo da controller de Registrar e especificando da onde está vindo tipo [FromServices] no caso do useCase e [FromBody] para a request

            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseClienteProfile), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserProfile([FromServices] IGetClienteProfileUseCase useCase)
        {
            var result = await useCase.Execute();

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Atualizar([FromServices] IUpdateClienteUseCase useCase, [FromBody] RequestUpdateCliente request)
        {
            await useCase.Execute(request);

            return NoContent();
        }
    }
}
