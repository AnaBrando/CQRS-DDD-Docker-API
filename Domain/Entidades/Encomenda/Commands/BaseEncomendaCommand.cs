using System;
using API.Core.Command;

namespace Domain.Entidades.Commands
{
    public class BaseEncomendaCommand : Command
    {
        public Guid Id { get; protected set; }

        public DateTime DataCadastro{get;set;}
        public Guid EquipeId { get; set; }
    }
}