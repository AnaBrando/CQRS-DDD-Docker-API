using System;

namespace Domain.Entidades.Commands
{
    public class ExcluirPedidoCommand : BasePedidoCommand
    {
            public ExcluirPedidoCommand(Guid id)
            {
                Id = id;
            }
    }
}