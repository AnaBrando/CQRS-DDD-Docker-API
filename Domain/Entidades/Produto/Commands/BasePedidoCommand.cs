using System;
using API.Core.Command;

namespace Domain.Entidades.Commands
{
  public class BaseProdutoCommand : Command
    {
        public Guid Id { get; protected set; }

        public DateTime DataCadastro{get;set;}

        public string Descricao { get; set; }
        public float Valor { get; set; }
        public DateTime DataAtualizacao{get;set;}
    }
}