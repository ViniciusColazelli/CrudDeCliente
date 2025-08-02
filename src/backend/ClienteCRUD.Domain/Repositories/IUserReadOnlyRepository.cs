namespace ClienteCRUD.Domain.Repositories
{
    public interface IUserReadOnlyRepository
    {
        public Task EmailJaRegistrado(string email);
    }
}
