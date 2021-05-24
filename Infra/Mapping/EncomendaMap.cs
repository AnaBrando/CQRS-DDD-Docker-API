using Domain.Entidades.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class EncomendaMap: IEntityTypeConfiguration<Encomenda>
    {
        public void Configure(EntityTypeBuilder<Encomenda> builder)
        {
           builder.ToTable("Encomendas");
           builder.HasKey(x=>x.Id);
           builder.HasOne(x=>x.Pedido);
        }
    }
}
