using System;
using System.Threading.Tasks;
using API.Core.Command;
using Core.Events;
using Core.Interfaces;
using MediatR;

namespace Core.Handlers
{
   public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public MediatorHandler
        (
            IMediator mediator, 
            IEventStore eventStore
        )
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }

        public async Task EnviarComando<T>(T comando) where T : Command
        {
            await _mediator.Send(comando);
            GC.Collect();
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {   
            if (!evento.MessageType.Equals("DomainNotification"))
                _eventStore?.SalvarEvento(evento);
            
            await _mediator.Publish(evento);
            GC.Collect();
        }
    }
}