using System;
using System.Collections.Generic;
using Core.Events;
using Infra.Context;
using Infra.EventSourcing;

namespace Infra.Repository
{
    public class EventStoreRepository : IEventStoragedRepository
    {
        private readonly EventContext _context;

        public EventStoreRepository(EventContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            //return (from e in _context.s where e.AggregateId == aggregateId select e).ToList();
            return null;
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
   
    }
}