using Domain.Entidades.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class EquipeMap : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
           builder.ToTable("Equipes");
           builder.HasKey(x=>x.Id);

        }
    }
}