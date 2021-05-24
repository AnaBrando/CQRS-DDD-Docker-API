using System;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Notification;
using Domain.DTO;
using Domain.DTO.Pedido;
using Domain.Interfaces.Service;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Route("Pedido")]
    [Authorize]
    public class PedidoController : BaseController
    {
        private readonly IPedidoService _service;
       
        public PedidoController
        (
            INotificationHandler<DomainNotification> notifications,
            IPedidoService service,
            IMediatorHandler mediator
        ) : base(notifications, mediator)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("obterPedidos")]
        public IActionResult Index(int paginaInicial, int paginaFinal)
        {
            return Response(_service.ObterTodosPedidos(paginaInicial,paginaFinal));
        }
  
        [HttpPost]
        [Route("cadastrarPedido")]
        public async Task<IActionResult> CadastrarPedido([FromBody]CadastroPedidoDTO dto)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.CadastrarPedido(dto));
        }

        [HttpPut]
        [Route("editarPedido/{id:guid}")]
        public async Task<IActionResult> EditarPedido(Guid id,[FromBody]PedidoDTO dto)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.EditarPedido(dto,id));
        }
        [HttpDelete]
        [Route("excluirPedido/(id:guid)")]
        public async Task<IActionResult> ExcluirPedido(Guid id)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.ExcluirPedido(id));
        }
    }
}