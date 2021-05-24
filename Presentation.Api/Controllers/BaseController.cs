using System;
using System.Linq;
using Core.Interfaces;
using Core.Notification;
using Domain.Intefaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        protected readonly DomainNotificationHandler _notifications;
        protected readonly IMediatorHandler _mediator;
        //protected readonly IUser _user;

        protected Guid UsuarioLogadoId { get; set; }

        protected BaseController
        (
            INotificationHandler<DomainNotification> notifications,
            //IUser user,
            IMediatorHandler mediator
        )
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
            //_user = user;

            //if (user.IsAuthenticated())
               // UsuarioLogadoId = user.GetUserId();
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
                return Ok(new
                {
                    success = true,
                    data = result
                });

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }

        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediator.PublicarEvento(new DomainNotification(codigo, mensagem));
        }

        protected bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }
    }
}