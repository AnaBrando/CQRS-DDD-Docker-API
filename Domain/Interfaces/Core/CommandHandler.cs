using Core.Intefaces;
using Core.Interfaces;
using Core.Notification;
using FluentValidation.Results;
using MediatR;

namespace Domain.Core
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly DomainNotificationHandler _notifications;
        protected readonly IMediatorHandler _mediator;

        protected CommandHandler
        (
            IUnitOfWork uow, 
            IMediatorHandler mediator, 
            INotificationHandler<DomainNotification> notifications
        )
        {
            _uow = uow;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _mediator.PublicarEvento(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _mediator.PublicarEvento(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no banco"));
            return false;
        }
    }
}