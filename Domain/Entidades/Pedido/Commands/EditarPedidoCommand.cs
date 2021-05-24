using System;
using System.Collections.Generic;

namespace Domain.Entidades.Commands
{
    public class EditarPedidoCommand : BasePedidoCommand
    {
        public List<EditarProdutoCommand> Produtos {get;set;}
        public EditarPedidoCommand(string endereco,DateTime dataEntrega,Guid id){
           Id = id;
           Endereco = endereco;
           DataEntrega = dataEntrega;
           DataAtualizacao = DateTime.Now;
        }
    }
}