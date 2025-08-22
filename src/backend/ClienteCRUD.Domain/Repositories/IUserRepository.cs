using ClienteCRUD.Domain.Entities;

namespace ClienteCRUD.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task Adicionar(User user);

        public Task<bool> ClienteAtivoComEmail(string email);

        public Task<User?> GetEmailAndPassword(string email, string senha);

        public Task<User> GetById(long id);

        public void Update(User user);
    }
}
