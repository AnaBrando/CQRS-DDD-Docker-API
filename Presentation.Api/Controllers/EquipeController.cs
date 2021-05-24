using System;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Notification;
using Domain.DTO;
using Domain.DTO.Equipe;
using Domain.Interfaces.Service;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Route("Equipe")]
    [Authorize]
    public class EquipeController : BaseController
    {
        private readonly IEquipeService _service;
       
        public EquipeController
        (
            INotificationHandler<DomainNotification> notifications,
            IEquipeService service,
            IMediatorHandler mediator
        ) : base(notifications, mediator)
        {
            _service = service;
        }
        [HttpGet]
        [Route("obterEquipes")]
        public IActionResult Index()
        {
            return Response(_service.ObterTodosEquipes());
        }
  
        [HttpPost]
        [Route("cadastrarEquipe")]
        public async Task<IActionResult> CadastrarEquipe([FromBody]AdicionaEquipeDTO dto)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.CadastrarEquipe(dto));
        }

        [HttpPut]
        [Route("editarEquipe/{id:guid}")]
        public async Task<IActionResult> EditarEquipe(Guid id,[FromBody]EquipeDTO dto)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.EditarEquipe(dto,id));
        }
        [HttpDelete]
        [Route("excluirEquipe/(id:guid)")]
        public async Task<IActionResult> ExcluirEquipe(Guid id)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.ExcluirEquipe(id));
        }
    }
}