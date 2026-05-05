namespace ClienteCRUD.Communication.Responses
{
    public class ResponseProdutoDetalhe
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal PrecoBase { get; set; }
        public List<ResponseGrupoOpcao> Opcoes { get; set; } = [];
    }

    public class ResponseGrupoOpcao
    {
        public string Tipo { get; set; } = string.Empty; // "gola", "cor", "tamanho"
        public List<ResponseOpcaoItem> Itens { get; set; } = [];
    }

    public class ResponseOpcaoItem
    {
        public string Valor { get; set; } = string.Empty;
        public decimal PrecoAdicional { get; set; }
    }
}
