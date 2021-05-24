using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Intefaces;
using Core.Interfaces;
using Core.Notification;
using Domain.Core;
using Domain.DTO;
using Domain.DTO.Equipe;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using MediatR;

namespace Domain.Entidades.Commands
{
    public class PedidoCommandHandler : CommandHandler,
            IRequestHandler<RegistrarPedidoCommand, bool>,
            IRequestHandler<EditarPedidoCommand, bool>,
            IRequestHandler<ExcluirPedidoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
 
        private readonly IMapper _mapper;
        public PedidoCommandHandler(
                IUnitOfWork uow,
                IMapper mapper, 
                IEquipeRepository equipeRepository,
                IPedidoRepository pedidoRepository,
                IMediatorHandler mediator, 
                INotificationHandler<DomainNotification> notifications) 
            : base(uow, mediator, notifications)
        {
 
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public Task<bool> Handle(EditarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = _pedidoRepository.ObterPorId(request.Id);
            pedido.DataEntrega = request.DataEntrega;
            pedido.Endereco = request.Endereco;
           _pedidoRepository.Atualizar(pedido);
            if (Commit()) { }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(ExcluirPedidoCommand request, CancellationToken cancellationToken)
        {
             var pedido = _pedidoRepository.ObterPorId(request.Id);
           _pedidoRepository.Excluir(pedido);
            if (Commit()) { }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RegistrarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = new Pedido();
            pedido.Produtos = _mapper.Map<List<Produto>>(request.Produtos);
            pedido.DataEntrega = request.DataEntrega;     
            pedido.Endereco = request.Endereco;
           _pedidoRepository.Adicionar(pedido);
            if (Commit()) { }

            return Task.FromResult(true);
        }

       
    }
}