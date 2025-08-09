using ClienteCRUD.Domain.Entities;
using ClienteCRUD.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClienteCRUD.Infrastructure.DataAcess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ClienteCrudDbContext _dbContext; // o readonly serve para que somente o construtor dessa classe no caso UserRepository que pode alterar a instancia do _dbContext

        public UserRepository(ClienteCrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(User user)
        {
            await _dbContext.Clientes.AddAsync(user);
        }

        public async Task<bool> EmailJaRegistrado(string email)
        {
            return await _dbContext.Clientes.AnyAsync(user => user.Email.Equals(email));
        }

        public async Task<User?> GetEmailAndPassword(string email, string senha)
        {
            return await _dbContext.Clientes.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email) && user.Senha.Equals(senha));
        }
    }
}
