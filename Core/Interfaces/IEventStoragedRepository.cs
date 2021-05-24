using System;
using System.Collections.Generic;
using Core.Events;

namespace Infra.EventSourcing
{
    public interface IEventStoragedRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
    
}