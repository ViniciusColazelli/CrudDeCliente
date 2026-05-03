using ClienteCRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClienteCRUD.Infrastructure.DataAcess.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(p => p.Total).HasColumnType("decimal(10,2)");
            builder.Property(p => p.CriadoEm).HasDefaultValueSql("NOW()");
            builder.HasOne(p => p.Cliente).WithMany().HasForeignKey(p => p.ClienteId);
            builder.HasMany(p => p.Itens).WithOne(i => i.Pedido).HasForeignKey(i => i.PedidoId);
        }
    }
}
