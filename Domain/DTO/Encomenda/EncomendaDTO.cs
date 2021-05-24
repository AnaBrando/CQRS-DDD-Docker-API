using System;
using System.Text.Json.Serialization;
using Domain.DTO.Equipe;

namespace Domain.DTO
{
    public class EncomendaDTO
    {

        public Guid Id {get;set;}

        public PedidoDTO Pedido {get;set;}

        public DateTime DataCadastro { get;set;}

        public Guid EquipeId{get;set;}

    }
}