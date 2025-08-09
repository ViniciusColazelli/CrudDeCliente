using ClienteCRUD.Application.UseCases.Login;
using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUsuarioRegistrado), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromServices] ILoginUsuarioUseCase useCase, [FromBody] RequestLoginUsuario request)
        {
            var result = await useCase.Execute(request);

            return Ok(result);
        }
    }
}
