using ClienteCRUD.Domain.Entities;

namespace ClienteCRUD.Domain.Repositories
{
    public interface IUserWriteOnlyRepository
    {
        public Task Adicionar(User user);
    }
}
