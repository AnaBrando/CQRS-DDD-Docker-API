using System;
using System.Collections.Generic;

namespace Domain.Entidades.Commands
{
    public class RegistrarEncomendaCommand : BaseEncomendaCommand
    {
        public RegistrarPedidoCommand Pedido {get;set;}
        public RegistrarEncomendaCommand( ){

        }
    }
}