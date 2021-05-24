using System;

namespace Domain.Entidades.Produto.Events
{
    public class ProdutoEditadoEvent : BaseProdutoEvent
    {
        public ProdutoEditadoEvent(Guid id, DateTime dataCadastro,string descricao){
                Id = id;
                DataCadastro = dataCadastro;
                Descricao = descricao;
        }
    }
}