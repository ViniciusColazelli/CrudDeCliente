using ClienteCRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

// essa classe ela é a ponte de comunicação entre a minha API e o banco de dados

namespace ClienteCRUD.Infrastructure.DataAcess
{
    public class ClienteCrudDbContext : DbContext
    {
        public ClienteCrudDbContext(DbContextOptions options) : base(options) { } // vou receber como parametro as opções do DbContextOptions e vou repassar para o construtor do DbContext
                                                                                 // por isso tem esse base(options)
        public DbSet<User> Clientes { get; set; } // esse DbSet é uma tabela e eu passo como parametro a entidade User tendo uma tabela com as propriedades do User no caso: nome, CPF, email e senha.

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteCrudDbContext).Assembly);
        }
    }
}
