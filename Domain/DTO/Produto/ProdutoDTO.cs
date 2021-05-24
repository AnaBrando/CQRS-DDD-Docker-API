using System;
using System.Text.Json.Serialization;

namespace Domain.DTO.Produto
{
    public class ProdutoDTO
    {
        public string Descricao { get; set; }

        public float Valor { get; set; }

        public Guid Id { get;  set;}   
     
        public DateTime DataCadastro { get;  set;}


    }
}