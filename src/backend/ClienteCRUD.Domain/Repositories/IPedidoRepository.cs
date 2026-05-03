namespace ClienteCRUD.Domain.Repositories
{
    public interface IPedidoRepository
    {
        Task Adicionar(Entities.Pedido pedido);
        Task<List<Entities.Pedido>> ListarPorCliente(int clienteId);
        Task<Entities.Pedido?> GetPorId(int id);
    }
}
