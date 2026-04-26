using ClienteCRUD.Domain.Entities;
using ClienteCRUD.Domain.Services.ClienteLogado;
using ClienteCRUD.Exceptions;
using ClienteCRUD.Exceptions.ExceptionBase;
using ClienteCRUD.Infrastructure.DataAcess;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ClienteCRUD.Infrastructure.Services.ClienteLogado
{
    public class ClienteLogado : IClienteLogado
    {
        private readonly ClienteCrudDbContext _dbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClienteLogado(ClienteCrudDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbcontext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<User> Cliente()
        {
            var clienteId = _httpContextAccessor.HttpContext!.Session.GetInt32("ClienteId");
            
            if (clienteId is null)
            {
                throw new ClienteNaoLogadoException();
            }

            return await _dbcontext.Clientes.AsNoTracking().FirstAsync(user => user.Id == clienteId && user.Active);
        }
    }
}
