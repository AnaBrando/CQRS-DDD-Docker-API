using System.Threading;
using System.Threading.Tasks;
using Domain.Entidades.Produto.Events;
using MediatR;

namespace Domain.Entidades.Events
{
    public class ProdutoEventHandler : 
        INotificationHandler<ProdutoRegistradoEvent>,
        INotificationHandler<ProdutoExcluidoEvent>
    {
        public Task Handle(ProdutoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProdutoExcluidoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
    
}