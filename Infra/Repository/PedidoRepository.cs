using Domain.Entidades.Commands;
using Domain.Interfaces;
using Infra.Context;

namespace Infra.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {     
        public PedidoRepository(BancoContext context) : base(context) {}
    }
}