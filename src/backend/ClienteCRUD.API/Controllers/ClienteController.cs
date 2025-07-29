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
        public IActionResult Registrar(RequestRegistrarUsuario request)
        {
            var useCase = new RegistrarUsuarioUseCase();

            var result = useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
