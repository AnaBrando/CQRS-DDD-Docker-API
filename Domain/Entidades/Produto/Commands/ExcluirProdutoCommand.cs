using System;

namespace Domain.Entidades.Commands
{
    public class ExcluirProdutoCommand : BasePedidoCommand
    {
            public ExcluirProdutoCommand(Guid id)
            {
                Id = id;
            }
    }
}