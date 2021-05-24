using System;
using System.Collections.Generic;

namespace Domain.Entidades.Commands
{
    public class RegistrarPedidoCommand : BasePedidoCommand
    {
        public List<RegistrarProdutoCommand> Produtos {get;set;}
        public RegistrarPedidoCommand(string endereco,DateTime dataEntrega){
            DataEntrega = dataEntrega;
            Endereco = endereco;
            Id = new System.Guid();
            DataCadastro = DateTime.Now;
        }
    }
}