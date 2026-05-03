using ClienteCRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClienteCRUD.Infrastructure.DataAcess.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.Property(i => i.PrecoUnitario).HasColumnType("decimal(10,2)");
            builder.Property(i => i.CustomizacaoJson).HasColumnType("jsonb").HasDefaultValue("{}");
            builder.HasOne(i => i.Produto).WithMany().HasForeignKey(i => i.ProdutoId);
        }
    }
}
