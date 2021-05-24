using System;

namespace Domain.Entidades.Commands
{
    public class EditarEquipeCommand : BaseEquipeCommand
    {
        public EditarEncomendaCommand Encomenda {get;set;}
        public EditarEquipeCommand(){
         
        }
    }
}