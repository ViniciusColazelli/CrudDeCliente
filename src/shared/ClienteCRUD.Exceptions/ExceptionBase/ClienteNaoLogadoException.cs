namespace ClienteCRUD.Exceptions.ExceptionBase
{
    public class ClienteNaoLogadoException : ClienteCrudException
    {
        public ClienteNaoLogadoException() : base(ResourceMensagensDeErro.CLIENTE_NAO_LOGADO)
        {
        }
    }
}
