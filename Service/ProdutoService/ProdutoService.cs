using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Core.Notification;
using Domain.DTO;
using Domain.DTO.Produto;
using Domain.Entidades.Commands;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using MediatR;
using Service.Base;

namespace Service.Produto
{
    public class ProdutoService : BaseService,IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _prepository;
        public ProdutoService(
         INotificationHandler<DomainNotification> notifications,
         IMediatorHandler mediator,
         IProdutoRepository pservice,
         IMapper mapper) : base(notifications, mediator)
        {
            _prepository = pservice;
            _mapper = mapper;
        }

        public async Task<ReponseDTO<ResponseSuccess>> CadastrarProduto(AdicionaProdutoDTO produto)
        {
            var command = _mapper.Map<RegistrarProdutoCommand>(produto);
            await _mediator.EnviarComando(command);
            if (!OperacaoValida())
            return new ReponseDTO<ResponseSuccess>(false);

            return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(new Guid()));    
        }

        public async Task<ReponseDTO<ResponseSuccess>> EditarProduto(ProdutoDTO produto, Guid Id)
        {
            produto.Id = Id;
            var command = _mapper.Map<EditarProdutoCommand>(produto);
            await _mediator.EnviarComando(command);
            if (!OperacaoValida())
            return new ReponseDTO<ResponseSuccess>(false);

            return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(command.Id));
        }

        public async Task<ReponseDTO<ResponseSuccess>> ExcluirProduto(Guid id)
        {
            var pedidoDTO = new ProdutoDTO() { Id = id };
            var command = _mapper.Map<ExcluirProdutoCommand>(pedidoDTO);
            await _mediator.EnviarComando(command);
            if (!OperacaoValida())
            return new ReponseDTO<ResponseSuccess>(false);

            return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(command.Id));
        }

        public List<ProdutoDTO> ObterTodosProdutos()
        {
            var result = _prepository.ObterTodos();
            
            return _mapper.Map<List<ProdutoDTO>>(result);
        }
    }
}