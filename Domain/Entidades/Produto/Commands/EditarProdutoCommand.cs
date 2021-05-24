using System;

namespace Domain.Entidades.Commands
{
    public class EditarProdutoCommand : BaseProdutoCommand
    {
        public EditarProdutoCommand(string descricao,float valor,Guid id){
           Id = id;
           Descricao = descricao;
           Valor = valor;
           DataAtualizacao = DateTime.Now;
        }
    }
}