using System;
using System.Text.Json.Serialization;

namespace Domain.DTO.Equipe
{
    public class EquipeDTO
    {
        public Guid Id {get;set;}

        public string Nome {get;set;}

        public string Descricao {get;set;}

        public string Placa {get;set;}
    }
}