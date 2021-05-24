using Core.Events;

namespace Domain.Intefaces
{
     public interface IEventStore
    {
        void SalvarEvento<T>(T evento) where T : Event;
    }
}