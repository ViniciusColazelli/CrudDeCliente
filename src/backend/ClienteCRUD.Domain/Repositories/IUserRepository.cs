using ClienteCRUD.Domain.Entities;

namespace ClienteCRUD.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task Adicionar(User user);

        public Task<bool> EmailJaRegistrado(string email);

        public Task<User?> GetEmailAndPassword(string email, string senha);
    }
}
