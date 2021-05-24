using Core.Events;
using Core.Interfaces;

namespace Infra.EventSourcing
{
    public class EventStore : IEventStore
    {
        public void SalvarEvento<T>(T evento) where T : Event
        {
            throw new System.NotImplementedException();
        }
    }
}