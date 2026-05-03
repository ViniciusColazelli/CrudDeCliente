using ClienteCRUD.Domain.Entities;
using ClienteCRUD.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClienteCRUD.Infrastructure.DataAcess.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ClienteCrudDbContext _context;
        public ProdutoRepository(ClienteCrudDbContext context) => _context = context;

        public async Task<List<Produto>> ListarAtivos()
        {
            return await _context.Produtos
                .AsNoTracking()
                .Where(p => p.Ativo)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<Produto?> GetPorId(int id)
        {
            return await _context.Produtos
                .AsNoTracking()
                .Include(p => p.Opcoes)
                .FirstOrDefaultAsync(p => p.Id == id && p.Ativo);
        }
    }
}
