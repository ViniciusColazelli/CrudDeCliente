using ClienteCRUD.Communication.Responses;
using ClienteCRUD.Exceptions;
using ClienteCRUD.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

// essa classe serve de filtro recebendo uma interface e tendo como padrão de implementação o metodo OnException
// e nesse metodo eu crio outros dois metodos que vão servir para indentificar se for uma exception esperada como a de ErroEmValidacaoException e fazendo com que ela mande uma mensagem de Erro esperada
// que ta sendo pega numa response de erros e o outro metodo serve para que caso tenha uma exceção que não é esperada ele mande uma mensagem de erro desconhecido salvo na nossa resource só para não
// mandar nenhuma mensagem mostrando os arquivos e informações pessoais.

namespace ClienteCRUD.API.Filtros
{
    public class FiltroException : IExceptionFilter
    {
        public void OnException(ExceptionContext contexto)
        {
            if (contexto.Exception is ClienteCrudException)
            {
                LidarComExceptions(contexto);
            }
            else
            {
                ThrowExceptionDesconhecida(contexto);
            }
        }

        private void LidarComExceptions(ExceptionContext contexto)
        {
            if (contexto.Exception is ErroEmLoginException)
            {
                contexto.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                contexto.Result = new UnauthorizedObjectResult(new ResponseErro(contexto.Exception.Message));
            }
            else if (contexto.Exception is ErroEmValidacaoException)
            {
                var exception = contexto.Exception as ErroEmValidacaoException;

                contexto.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                contexto.Result = new BadRequestObjectResult(new ResponseErro(exception!.MensagemDeErro));
            }
        }

        private void ThrowExceptionDesconhecida(ExceptionContext contexto)
        {
            contexto.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            contexto.Result = new ObjectResult(new ResponseErro(ResourceMensagensDeErro.ERRO_DESCONHECIDO));
        }
    }
}
