using System;

namespace Domain.Entidades.Commands
{
    public class ExcluirEquipeCommand : BasePedidoCommand
    {
            public ExcluirEquipeCommand(Guid id)
            {
                Id = id;
            }
    }
}