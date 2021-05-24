using System;
using Core.Events;
using MediatR;

namespace API.Core.Command
{
    public class Command : Message, IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}

