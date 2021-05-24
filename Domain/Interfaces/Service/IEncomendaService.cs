using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.DTO.Encomenda;

namespace Domain.Interfaces.Service
{
    public interface IEncomendaService
    {
        Task<ReponseDTO<ResponseSuccess>> CadastrarEncomenda(CadastrarEncomendaDTO produto);
        Task<ReponseDTO<ResponseSuccess>> EditarEncomenda(EncomendaDTO produto, Guid Id);
        Task<ReponseDTO<ResponseSuccess>> ExcluirEncomenda(Guid Id);
        List<EncomendaDTO> ObterTodosEncomendas();

        Guid DirecionarEncomendaEquipeId();
    }
}