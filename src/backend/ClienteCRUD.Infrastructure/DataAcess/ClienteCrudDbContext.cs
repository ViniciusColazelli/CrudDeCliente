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
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoOpcao> ProdutoOpcoes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteCrudDbContext).Assembly);

            // Configurações para converter nomes no banco de dados para snake_case
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(ToSnakeCase(entity.GetTableName()!));

                foreach (var property in entity.GetProperties())
                    property.SetColumnName(ToSnakeCase(property.GetColumnName()!));

                foreach (var key in entity.GetKeys())
                    key.SetName(ToSnakeCase(key.GetName()!));

                foreach (var fk in entity.GetForeignKeys())
                    fk.SetConstraintName(ToSnakeCase(fk.GetConstraintName()!));
            }
        }
        private static string ToSnakeCase(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            return string.Concat(name.Select((c, i) =>
                i > 0 && char.IsUpper(c) ? "_" + c.ToString() : c.ToString()
            )).ToLower();
        }
    }
}
