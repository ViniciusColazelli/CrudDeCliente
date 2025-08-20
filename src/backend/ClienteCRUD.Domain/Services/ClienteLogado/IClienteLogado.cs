using ClienteCRUD.Domain.Entities;

namespace ClienteCRUD.Domain.Services.ClienteLogado
{
    public interface IClienteLogado
    {
        public Task<User> Cliente();
    }
}
