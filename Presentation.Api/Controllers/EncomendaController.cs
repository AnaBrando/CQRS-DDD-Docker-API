using System;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Notification;
using Domain.DTO;
using Domain.DTO.Encomenda;
using Domain.Interfaces.Service;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Route("Encomenda")]
    [Authorize]
    public class EncomendaController : BaseController
    {
        private readonly IEncomendaService _service;
       
        public EncomendaController
        (
            INotificationHandler<DomainNotification> notifications,
            IEncomendaService service,
            IMediatorHandler mediator
        ) : base(notifications, mediator)
        {
            _service = service;
        }
        [HttpGet]
        [Route("obterEncomendas")]
        public IActionResult Index()
        {
            return Response(_service.ObterTodosEncomendas());
        }
  
        [HttpPost]
        [Route("cadastrarEncomenda")]
        public async Task<IActionResult> CadastrarEncomenda([FromBody]CadastrarEncomendaDTO dto)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.CadastrarEncomenda(dto));
        }

        [HttpPut]
        [Route("editarEncomenda/{id:guid}")]
        public async Task<IActionResult> EditarEncomenda(Guid id,[FromBody]EncomendaDTO dto)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.EditarEncomenda(dto,id));
        }
        [HttpDelete]
        [Route("excluirEncomenda/(id:guid)")]
        public async Task<IActionResult> ExcluirEncomenda(Guid id)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.ExcluirEncomenda(id));
        }
    }
}