using System;

namespace Domain.Entidades.Commands
{
    public class EditarEncomendaCommand : BaseEncomendaCommand
    {
        public EditarPedidoCommand Pedido {get;set;}
        public EditarEncomendaCommand(){
         
        }
    }
}