using System;

namespace Domain.Entidades.Produto.Events
{
    public class ProdutoExcluidoEvent : BaseProdutoEvent
    {
        public ProdutoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}