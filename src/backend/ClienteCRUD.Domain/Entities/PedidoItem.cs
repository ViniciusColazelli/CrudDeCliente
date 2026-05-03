namespace ClienteCRUD.Domain.Entities
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; } = 1;
        public decimal PrecoUnitario { get; set; }
        public string CustomizacaoJson { get; set; } = "{}"; // snapshot da customização: { "gola": "V", "cor": "Azul", "tamanho": "M" }
        public string? LogoUrl { get; set; }
        public Pedido Pedido { get; set; } = null!;
        public Produto Produto { get; set; } = null!;
    }
}
