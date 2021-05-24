using System;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Notification;
using Domain.DTO;
using Domain.DTO.Produto;
using Domain.Intefaces;
using Domain.Interfaces.Service;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Api.Controllers
{
    [Route("Produto")]
    [Authorize]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _service;
       
        public ProdutoController
        (
            INotificationHandler<DomainNotification> notifications,
            IProdutoService service,
            IMediatorHandler mediator
        ) : base(notifications, mediator)
        {
            _service = service;
        }

        [HttpGet]
        [Route("obterProdutos")]
        public IActionResult Index()
        {
            return Response(_service.ObterTodosProdutos());
        }
  
        [HttpPost]
        [Route("cadastrarProduto")]
        public async Task<IActionResult> CadastrarProduto([FromBody]AdicionaProdutoDTO dto)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.CadastrarProduto(dto));
        }

        [HttpPut]
        [Route("editarProduto/{id:guid}")]
        public async Task<IActionResult> EditarProduto(Guid id,[FromBody]ProdutoDTO dto)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.EditarProduto(dto,id));
        }
        [HttpDelete]
        [Route("excluirProduto/(id:guid)")]
        public async Task<IActionResult> ExcluirProduto(Guid id)
        {
             if (!ModelStateValida())
                return Response();

            return Response(await _service.ExcluirProduto(id));
        }
    }
}