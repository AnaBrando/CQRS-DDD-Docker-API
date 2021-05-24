using System;
using Core.Interfaces;
using Core.Notification;
using Domain.Intefaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Service.Base
{
    public class BaseService
    { 
        protected readonly DomainNotificationHandler _notifications;
        protected readonly IMediatorHandler _mediator;
        //protected readonly IUser _user;

        protected Guid UsuarioLogadoId { get; set; }

        public BaseService
        (
            //IUser user,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator
        )
        {
            //_user = user;
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
            //UsuarioLogadoId = user.GetUserId();
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediator.PublicarEvento(new DomainNotification(codigo, mensagem));
        }

        protected void AdicionarErrosIdentity(IdentityResult result)
        {
            foreach (var error in result.Errors) NotificarErro(result.ToString(), error.Description);
        }
    }
}