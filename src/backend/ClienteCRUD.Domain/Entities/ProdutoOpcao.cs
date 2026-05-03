namespace ClienteCRUD.Domain.Entities
{
    public class ProdutoOpcao
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string Tipo { get; set; } = string.Empty;   // "gola", "cor", "tamanho", "tecido", "bolso"
        public string Valor { get; set; } = string.Empty;  // "V", "Azul", "M", "Sim"...
        public decimal PrecoAdicional { get; set; } = 0;
        public Produto Produto { get; set; } = null!;
    }
}
