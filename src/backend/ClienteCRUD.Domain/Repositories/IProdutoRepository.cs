namespace ClienteCRUD.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Entities.Produto>> ListarAtivos();
        Task<Entities.Produto?> GetPorId(int id);
    }
}
