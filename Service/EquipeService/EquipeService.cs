using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Core.Notification;
using Domain.DTO;
using Domain.DTO.Equipe;
using Domain.Entidades.Commands;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service;
using MediatR;
using Service.Base;

namespace Service.EquipeService
{
    public class EquipeService : BaseService, IEquipeService
    {
        private readonly IMapper _mapper;
        private readonly IEquipeRepository _repoEquipe;
        public EquipeService(INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator, IMapper mapper,IEquipeRepository repoEquipe) : base(notifications, mediator)
        {
            _mapper = mapper;
            _repoEquipe = repoEquipe;
        }

       public async Task<ReponseDTO<ResponseSuccess>> CadastrarEquipe(AdicionaEquipeDTO Equipe)
        {
            var command = _mapper.Map<RegistrarEquipeCommand>(Equipe);
            await _mediator.EnviarComando(command);
            if (!OperacaoValida())
            return new ReponseDTO<ResponseSuccess>(false);

            return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(Guid.NewGuid()));    

        }

        public async Task<ReponseDTO<ResponseSuccess>> EditarEquipe(EquipeDTO Equipe, Guid id)
        {
           Equipe.Id = id;
           var command = _mapper.Map<EditarEquipeCommand>(Equipe);

           await _mediator.EnviarComando(command);
           if (!OperacaoValida())
           return new ReponseDTO<ResponseSuccess>(false);

           return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(Guid.NewGuid()));  
        }

        public async Task<ReponseDTO<ResponseSuccess>> ExcluirEquipe(Guid id)
        {
            var EquipeDTO = new EquipeDTO() { Id = id };
            var command = _mapper.Map<ExcluirEquipeCommand>(EquipeDTO);
            await _mediator.EnviarComando(command);
            if (!OperacaoValida())
            return new ReponseDTO<ResponseSuccess>(false);

            return new ReponseDTO<ResponseSuccess>(true, new ResponseSuccess(Guid.NewGuid()));  
        }

        public List<EquipeDTO> ObterTodosEquipes()
        {
            var result = _repoEquipe.ObterTodos();
            return _mapper.Map<List<EquipeDTO>>(result);
        }
    }
}