using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Core.Notification;
using Domain.DTO;
using Domain.DTO.Equipe;
using Domain.DTO.Pedido;
using Domain.Entidades.Commands;
using Domain.Interfaces;
using Domain.Interfaces.Service;
using MediatR;
using Service.Base;

namespace Service.PedidoService
{
    public class PedidoService : BaseService,IPedidoService
    {
        public readonly IPedidoRepository _produtoRepository;
        public readonly IMapper _mapper;

        public PedidoService(IPedidoRepository produtoRepository,
                                IMapper mapper ,
                                INotificationHandler<DomainNotification> notification,
            IMediatorHandler mediator
        ) : base(notification, mediator)
        {
                _mapper = mapper;
                _produtoRepository = produtoRepository;
        }

        public async Task<ReponseDTO<ResponseSuccess>> CadastrarPedido(CadastroPedidoDTO produto)
        {       
            var command = _mapper.Map<RegistrarPedidoCommand>(produto);
            await _mediator.EnviarComando(command);
            if (!OperacaoValida())
            return new ReponseDTO<ResponseSuccess>(false);

            return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(Guid.NewGuid()));    
        }

       

        public async Task<ReponseDTO<ResponseSuccess>> EditarPedido(PedidoDTO produto, Guid Id)
        {
            produto.Id = Id;
            var command = _mapper.Map<EditarPedidoCommand>(produto);
            await _mediator.EnviarComando(command);
            if (!OperacaoValida())
            return new ReponseDTO<ResponseSuccess>(false);

            return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(Guid.NewGuid()));
                       
        }

        public async Task<ReponseDTO<ResponseSuccess>> ExcluirPedido(Guid id)
        {
            var produtoDTO = new PedidoDTO() { Id = id };
            var command = _mapper.Map<ExcluirPedidoCommand>(produtoDTO);
            await _mediator.EnviarComando(command);
            if (!OperacaoValida())
            return new ReponseDTO<ResponseSuccess>(false);

            return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(Guid.NewGuid()));
        }

        public List<PedidoDTO> ObterTodosPedidos(int paginaInicial, int paginaFinal)
        {
            var paginacao = paginaInicial + paginaFinal;
            var result = _produtoRepository.ObterTodos().OrderBy(x=>x.DataCadastro).Take(paginacao);
            
            return _mapper.Map<List<PedidoDTO>>(result);
        }

        
    }
}