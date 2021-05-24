using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Intefaces;
using Core.Interfaces;
using Core.Notification;
using Domain.Core;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using MediatR;

namespace Domain.Entidades.Commands
{
    public class EquipeCommandHandler : CommandHandler,
            IRequestHandler<RegistrarEquipeCommand, bool>,
            IRequestHandler<EditarEquipeCommand, bool>,
            IRequestHandler<ExcluirEquipeCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IEquipeRepository _repoEncomenda;
        public EquipeCommandHandler(
                IUnitOfWork uow,
                IMapper mapper, 
                IMediatorHandler mediator, 
                IPedidoRepository pedidoRepository,
                IEquipeRepository repoEncomenda,
                INotificationHandler<DomainNotification> notifications) 
            : base(uow, mediator, notifications)
        {
            _repoEncomenda = repoEncomenda;
            _mapper = mapper;
        }

        public Task<bool> Handle(EditarEquipeCommand request, CancellationToken cancellationToken)
        {
            var equipe = _repoEncomenda.ObterPorId(request.Id);
            equipe.Nome = request.Nome;
            equipe.Placa = request.Placa;
            equipe.Descricao = request.Descricao;
           _repoEncomenda.Atualizar(equipe);
            if (Commit()) { }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RegistrarEquipeCommand request, CancellationToken cancellationToken)
        {
     
            var equipe = new Equipe();
            equipe.Nome = request.Nome;
            equipe.Placa = request.Placa;
            equipe.Descricao = request.Descricao;
            _repoEncomenda.Adicionar(equipe);
            if (Commit()) { }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(ExcluirEquipeCommand request, CancellationToken cancellationToken)
        {
            var equipe = _repoEncomenda.ObterPorId(request.Id);
           _repoEncomenda.Excluir(equipe);
            if (Commit()) { }

            return Task.FromResult(true);
        }
    }
}