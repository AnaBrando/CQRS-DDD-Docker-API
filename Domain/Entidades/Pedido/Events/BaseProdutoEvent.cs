using System;
using Core.Events;

namespace Domain.Entidades.Produto.Events
{
    public class BaseProdutoEvent : Event
    {
        public Guid Id{get;set;}
        public DateTime DataCadastro{get;set;}

        public string Descricao { get; set; }
    }
}