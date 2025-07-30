namespace ClienteCRUD.Exceptions.ExceptionBase
{
    public class ErroEmValidacaoException : ClienteCrudException
    {
        public IList<string> MensagemDeErro { get; set; }

        public ErroEmValidacaoException(IList<string> MensagensDeErros)
        {
            MensagemDeErro = MensagensDeErros;
        }
    }
}
