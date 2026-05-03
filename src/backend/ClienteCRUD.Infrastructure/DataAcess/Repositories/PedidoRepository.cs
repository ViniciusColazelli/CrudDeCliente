using ClienteCRUD.Domain.Entities;
using ClienteCRUD.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClienteCRUD.Infrastructure.DataAcess.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ClienteCrudDbContext _context;
        public PedidoRepository(ClienteCrudDbContext context) => _context = context;

        public async Task Adicionar(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
        }

        public async Task<List<Pedido>> ListarPorCliente(int clienteId)
        {
            return await _context.Pedidos
                .AsNoTracking()
                .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
                .Where(p => p.ClienteId == clienteId)
                .OrderByDescending(p => p.CriadoEm)
                .ToListAsync();
        }

        public async Task<Pedido?> GetPorId(int id)
        {
            return await _context.Pedidos
                .AsNoTracking()
                .Include(p => p.Itens)
                .ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
