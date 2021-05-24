using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Core.Notification;
using Domain.DTO;
using Domain.DTO.Encomenda;
using Domain.Entidades.Commands;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using MediatR;
using Service.Base;

namespace Service.EncomendaService
{
    public class EncomendaService : BaseService,IEncomendaService
    {
        private readonly IMapper _mapper;
        private readonly IEncomendaRepository _encomendaRepository;

        private readonly IEquipeRepository _equipeRepository;
        public EncomendaService(INotificationHandler<DomainNotification> notifications,
         IMediatorHandler mediator,IMapper mapper,
         IEquipeRepository equipeRepository,IEncomendaRepository encomendaRepository) : base(notifications, mediator)
        {
            _mapper = mapper;
            _encomendaRepository = encomendaRepository;
            _equipeRepository = equipeRepository;
        }

        public async Task<ReponseDTO<ResponseSuccess>> CadastrarEncomenda(CadastrarEncomendaDTO encomenda)
        {
            var pedidoCommand = _mapper.Map<RegistrarPedidoCommand>(encomenda.Pedido);
            var command = new RegistrarEncomendaCommand();
            command.Pedido = pedidoCommand;
            command.EquipeId = DirecionarEncomendaEquipeId();
            await _mediator.EnviarComando(command);
            if (!OperacaoValida())
            return new ReponseDTO<ResponseSuccess>(false);

            return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(Guid.NewGuid()));    

        }

        public Guid DirecionarEncomendaEquipeId()
        {
            return _equipeRepository.ObterTodos().FirstOrDefault().Id;
        }

        public async Task<ReponseDTO<ResponseSuccess>> EditarEncomenda(EncomendaDTO encomenda, Guid id)
        {
           encomenda.Id = id;
           var command = _mapper.Map<EditarEncomendaCommand>(encomenda);

           await _mediator.EnviarComando(command);
           if (!OperacaoValida())
           return new ReponseDTO<ResponseSuccess>(false);

           return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(Guid.NewGuid()));  
        }

        public async Task<ReponseDTO<ResponseSuccess>> ExcluirEncomenda(Guid id)
        {
            var encomendaDTO = new EncomendaDTO() { Id = id };
            var command = _mapper.Map<ExcluirEncomendaCommand>(encomendaDTO);
            await _mediator.EnviarComando(command);
            if (!OperacaoValida())
            return new ReponseDTO<ResponseSuccess>(false);

            return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(Guid.NewGuid()));  
        }

        public List<EncomendaDTO> ObterTodosEncomendas()
        {
            var result = _encomendaRepository.ObterTodos();
            return _mapper.Map<List<EncomendaDTO>>(result);
        }
    }
}