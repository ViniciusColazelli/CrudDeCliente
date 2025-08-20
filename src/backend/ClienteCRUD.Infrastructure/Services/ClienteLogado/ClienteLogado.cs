using ClienteCRUD.Domain.Entities;
using ClienteCRUD.Domain.Services.ClienteLogado;
using ClienteCRUD.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace ClienteCRUD.Infrastructure.Services.ClienteLogado
{
    public class ClienteLogado : IClienteLogado
    {
        private readonly ClienteCrudDbContext _dbcontext;
        public ClienteLogado(ClienteCrudDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<User> Cliente()
        {
            return await _dbcontext.Clientes.AsNoTracking().FirstAsync(user => user.Active);
        }
    }
}
