using API.Core.Entity;
using Domain.Entidades.Commands;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Domain.Entidades.Commands
{
    public class Equipe : Entity<Equipe>
    {
        public string Nome{get;set;}

        public string Descricao{get;set;}

        public string Placa{get;set;}
    }
}