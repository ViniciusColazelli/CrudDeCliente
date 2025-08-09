namespace ClienteCRUD.Exceptions.ExceptionBase
{
    public class ErroEmLoginException : ClienteCrudException
    {
        public ErroEmLoginException() : base(ResourceMensagensDeErro.EMAIL_OU_SENHA_INVALIDO)
        {
        }
    }
}
