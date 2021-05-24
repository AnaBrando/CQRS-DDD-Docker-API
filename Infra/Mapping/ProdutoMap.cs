using Domain.Entidades.Commands;
using Domain.Entidades.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class ProdutoMap: IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
           
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);
            
        }
    }
}