namespace ClienteCRUD.Communication.Responses
{
    public class ResponsePedidoCriado
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
