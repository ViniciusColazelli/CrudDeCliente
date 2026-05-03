using ClienteCRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClienteCRUD.Infrastructure.DataAcess.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.PrecoBase).HasColumnType("decimal(10,2)");
            builder.HasMany(p => p.Opcoes)
                   .WithOne(o => o.Produto)
                   .HasForeignKey(o => o.ProdutoId);
        }
    }
}
