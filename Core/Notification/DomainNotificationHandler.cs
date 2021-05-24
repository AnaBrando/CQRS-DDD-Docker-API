using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Core.Notification
{
   public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro: {message.Key} - {message.Value}");
            Console.ForegroundColor = ConsoleColor.Gray;

            return Task.CompletedTask;
        }

        public virtual bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}