namespace ClienteCRUD.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal PrecoBase { get; set; }
        public bool Ativo { get; set; } = true;
        public ICollection<ProdutoOpcao> Opcoes { get; set; } = [];
    }
}
