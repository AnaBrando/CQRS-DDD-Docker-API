using System;

namespace Domain.Entidades.Commands
{
    public class RegistrarProdutoCommand : BaseProdutoCommand
    {
        public RegistrarProdutoCommand(string descricao,float valor){
            Descricao = descricao;
            Valor = valor;
            Id = new System.Guid();
            DataCadastro = DateTime.Now;
        }
    }
}