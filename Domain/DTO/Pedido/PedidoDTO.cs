using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Domain.DTO.Produto;

namespace Domain.DTO
{
    public class PedidoDTO 
    {
        public PedidoDTO (){
            Produtos = new List<ProdutoDTO>();
        }
        public string Endereco { get; set; }
     
         public DateTime DataEntrega { get; set; }

         public List<ProdutoDTO> Produtos {get;set;}

         public Guid Id{get; set;}

         public DateTime DataCadastro {get;protected set;}
         
    }
}