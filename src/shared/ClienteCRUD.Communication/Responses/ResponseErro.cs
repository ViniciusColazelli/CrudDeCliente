namespace ClienteCRUD.Communication.Responses
{
    public class ResponseErro
    {
        public IList<string> Erros { get; set; }

        public ResponseErro(IList<string> erros) // lista de erros
        {
            Erros = erros;
        }

        public ResponseErro(string erro) // vai criar uma lista pra uma mensagem só. que é passado como parametro
        {
            Erros = new List<string>()
            {
                erro
            };
        }
    }
}
