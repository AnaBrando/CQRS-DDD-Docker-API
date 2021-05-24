using System;
using API.Core.Command;

namespace Domain.Entidades.Commands
{
    public class BaseEquipeCommand : Command
    {
        public Guid Id { get; protected set; }

        public DateTime DataCadastro{get;set;}
        public string Nome{get;set;}

        public string Descricao{get;set;}

        public string Placa{get;set;}

    }
}