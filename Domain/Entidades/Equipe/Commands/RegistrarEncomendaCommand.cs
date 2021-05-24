using System;
using System.Collections.Generic;

namespace Domain.Entidades.Commands
{
    public class RegistrarEquipeCommand : BaseEquipeCommand
    {
        public RegistrarEncomendaCommand Encomenda {get;set;}
        public RegistrarEquipeCommand(){
        
        }
    }
}