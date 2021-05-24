using System;

namespace Domain.Entidades.Commands
{
    public class ExcluirEncomendaCommand : BasePedidoCommand
    {
            public ExcluirEncomendaCommand(Guid id)
            {
                Id = id;
            }
    }
}