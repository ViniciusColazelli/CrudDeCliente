using ClienteCRUD.Application.UseCases.Login;
using ClienteCRUD.Application.UseCases.Registrar;
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
    }
}
