using ClienteCRUD.Domain.Repositories;

namespace ClienteCRUD.Infrastructure.DataAcess
{
    public class SalvarDB : ISalvarDB
    {
        private readonly ClienteCrudDbContext _dbContext;

        public SalvarDB(ClienteCrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
