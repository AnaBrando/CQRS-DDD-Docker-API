using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Intefaces;
using Core.Interfaces;
using Core.Notification;
using Domain.Core;
using Domain.DTO.Equipe;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using MediatR;

namespace Domain.Entidades.Commands
{
    public class EncomendaCommandHandler : CommandHandler,
            IRequestHandler<RegistrarEncomendaCommand, bool>,
            IRequestHandler<EditarEncomendaCommand, bool>,
            IRequestHandler<ExcluirEncomendaCommand, bool>
    {
        private readonly IEncomendaRepository _EncomendaRepository;
        private readonly IPedidoRepository _pedidoRepository;

        private readonly IEquipeRepository _equipeRepo;
        private readonly IMapper _mapper;
        public EncomendaCommandHandler(
                IUnitOfWork uow,
                IMapper mapper, 
                IEncomendaRepository EncomendaRepository,
                IMediatorHandler mediator, 
                IEquipeRepository equipeRepo,
                IPedidoRepository pedidoRepository,
                INotificationHandler<DomainNotification> notifications) 
            : base(uow, mediator, notifications)
        {
            _pedidoRepository = pedidoRepository;
            _EncomendaRepository = EncomendaRepository;
            _mapper = mapper;
            _equipeRepo = equipeRepo;
        }

        public Task<bool> Handle(RegistrarEncomendaCommand request, CancellationToken cancellationToken)
        {
            var pedido = new Pedido();     
            pedido.Endereco = request.Pedido.Endereco;
            pedido.DataEntrega = request.Pedido.DataEntrega;
            pedido.Produtos = _mapper.Map<List<Produto>>(request.Pedido.Produtos);       
            var encomenda = new Encomenda();
            encomenda.Pedido = pedido;
            encomenda.EquipeId =request.EquipeId;
            _EncomendaRepository.Adicionar(encomenda);
                    
            if (Commit()) { }
            
            return Task.FromResult(true);
        }

        public Task<bool> Handle(EditarEncomendaCommand request, CancellationToken cancellationToken)
        {
            var encomenda = _EncomendaRepository.ObterPorId(request.Id);            
            encomenda.Pedido.Endereco = request.Pedido.Endereco;
            encomenda.Pedido.DataEntrega = request.Pedido.DataEntrega; 
   
           _EncomendaRepository.Atualizar(encomenda);
            if (Commit()) { }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(ExcluirEncomendaCommand request, CancellationToken cancellationToken)
        {
            var encomenda = _EncomendaRepository.ObterPorId(request.Id);
            var pedido = _EncomendaRepository.ObterPorId(request.Id).Pedido;
            _pedidoRepository.Excluir(pedido);
            _EncomendaRepository.Excluir(encomenda);
            if (Commit()) { }

            return Task.FromResult(true);
        }
      
    }
}