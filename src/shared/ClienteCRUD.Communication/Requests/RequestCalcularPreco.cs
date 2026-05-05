namespace ClienteCRUD.Communication.Requests
{
    public class RequestCalcularPreco
    {
        public int ProdutoId { get; set; }
        public Dictionary<string, string> Customizacao { get; set; } = [];
        // Ex: { "gola": "V", "cor": "Azul", "tamanho": "M" }
    }
}
