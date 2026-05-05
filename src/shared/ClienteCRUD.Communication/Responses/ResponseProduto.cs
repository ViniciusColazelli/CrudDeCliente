namespace ClienteCRUD.Communication.Responses
{
    public class ResponseProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal PrecoBase { get; set; }
    }
}
