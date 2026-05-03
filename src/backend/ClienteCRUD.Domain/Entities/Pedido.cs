namespace ClienteCRUD.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Status { get; set; } = "pendente"; // pendente, confirmado, em_producao, entregue, cancelado
        public decimal Total { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public User Cliente { get; set; } = null!;
        public ICollection<PedidoItem> Itens { get; set; } = [];
    }
}
