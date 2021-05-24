using System;
using System.Collections.Generic;
using API.Core.Command;

namespace Domain.Entidades.Commands
{
  public class BasePedidoCommand : Command
    {
        public Guid Id { get; protected set; }

        public DateTime DataCadastro{get;set;}

        public string Endereco { get; set; }

        public DateTime DataEntrega { get; set; }

        public DateTime DataAtualizacao{get;set;}

     
    }
}