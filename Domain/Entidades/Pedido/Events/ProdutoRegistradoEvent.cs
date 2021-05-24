using System;

namespace Domain.Entidades.Produto.Events
{
    public class ProdutoRegistradoEvent : BaseProdutoEvent
    {
        public ProdutoRegistradoEvent(Guid id, DateTime dataCadastro,string descricao)
        {
            Id = id;
            DataCadastro = dataCadastro;           
            Descricao = descricao;
        }
    }
}