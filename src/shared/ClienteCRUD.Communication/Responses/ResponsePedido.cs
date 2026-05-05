namespace ClienteCRUD.Communication.Responses
{
    public class ResponsePedido
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public DateTime CriadoEm { get; set; }
        public List<ResponsePedidoItem> Itens { get; set; } = [];
    }

    public class ResponsePedidoItem
    {
        public string ProdutoNome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public Dictionary<string, string> Customizacao { get; set; } = [];
        public string? LogoUrl { get; set; }
    }
}
