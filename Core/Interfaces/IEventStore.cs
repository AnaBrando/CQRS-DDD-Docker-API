using Core.Events;

namespace Core.Interfaces
{
    public interface IEventStore
    {
        void SalvarEvento<T>(T evento) where T : Event;
    }
}