namespace ClienteCRUD.Communication.Requests
{
    public class RequestCriarPedidoItem
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; } = 1;
        public Dictionary<string, string> Customizacao { get; set; } = [];
        public string? LogoUrl { get; set; }
    }
}
