
using Domain.Entidades.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
           builder.ToTable("Pedidos");
           builder.HasKey(x=>x.Id);
           builder.HasMany(x=>x.Produtos);
        }
    }
}