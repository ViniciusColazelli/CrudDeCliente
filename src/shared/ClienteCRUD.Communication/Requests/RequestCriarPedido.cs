namespace ClienteCRUD.Communication.Requests
{
    public class RequestCriarPedido
    {
        public List<RequestCriarPedidoItem> Itens { get; set; } = [];
    }
}
