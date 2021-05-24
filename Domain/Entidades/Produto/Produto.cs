using System;
using API.Core.Entity;

namespace Domain.Entidades.Commands
{
    public class Produto : Entity<Produto>
    {
        public string Descricao { get; set; }

        public float Valor { get; set; }


    }
}