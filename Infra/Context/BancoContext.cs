using Domain.Entidades.Commands;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class BancoContext : DbContext {
     
        public BancoContext(DbContextOptions<BancoContext> options): base(options){
            
        }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Encomenda> Encomenda { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
        public BancoContext() { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new EncomendaMap());
            modelBuilder.ApplyConfiguration(new EquipeMap());
            base.OnModelCreating(modelBuilder);
        }

   }

}