using ClienteCRUD.Application.Services.Criptografia;
using ClienteCRUD.Application.Services.Mapeamento;
using ClienteCRUD.Communication.Requests;
using ClienteCRUD.Communication.Responses;
using ClienteCRUD.Exceptions.ExceptionBase;

namespace ClienteCRUD.Application.UseCases.Registrar
{
    public class RegistrarUsuarioUseCase
    {
        public ResponseUsuarioRegistrado Execute(RequestRegistrarUsuario request) // metodo para executar a request, dentro dela tera as nossas regras de negocio para registrar um cliente.
        {
            Validate(request);

            // mapear a request pra uma entidade
            var user = MapearRequest.RequestParaEntidade(request);

            // Criptografar a senha
            var criptografiaDeSenha = new SenhaCriptografada();
            user.Senha = criptografiaDeSenha.Criptografia(request.Senha);

            // Salvar no banco de dados


            return new ResponseUsuarioRegistrado
            {
                Nome = request.Nome
            };
        }

        // esse metodo validate vai validar se a request é valida de acordo com o nosso RegistrarUsuarioValidator e
        // tem um if para se o resultado for invalido retornar uma mensagem de erro.
        private void Validate(RequestRegistrarUsuario request)
        {
            var validator = new RegistrarUsuarioValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var mensagemErro = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErroEmValidacaoException(mensagemErro);
            }
        }
    }
}
