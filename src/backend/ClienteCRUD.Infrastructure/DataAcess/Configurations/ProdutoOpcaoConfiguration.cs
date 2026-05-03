using ClienteCRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClienteCRUD.Infrastructure.DataAcess.Configurations
{
    public class ProdutoOpcaoConfiguration : IEntityTypeConfiguration<ProdutoOpcao>
    {
        public void Configure(EntityTypeBuilder<ProdutoOpcao> builder)
        {
            builder.Property(o => o.PrecoAdicional).HasColumnType("decimal(10,2)");
        }
    }
}
