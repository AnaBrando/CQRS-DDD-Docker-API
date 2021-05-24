using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.DTO.Produto;

namespace Domain.DTO.Pedido
{
    public class CadastroPedidoDTO
    {
          public CadastroPedidoDTO (){
            Produtos = new List<AdicionaProdutoDTO>();
        }
        [Required(ErrorMessage="O campo descrição do produto é obrigatório")]
        public string Endereco { get; set; }
        [Required(ErrorMessage="O campo descrição do produto é obrigatório")]
         public DateTime DataEntrega { get; set; }
        [Required(ErrorMessage="Um pedido deve ter pelo menos um produto")]
         public List<AdicionaProdutoDTO> Produtos {get;set;}



    }
}