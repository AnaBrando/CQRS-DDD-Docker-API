using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.DTO.Equipe;

namespace Domain.Interfaces.Service
{
    public interface IEquipeService
    {
        Task<ReponseDTO<ResponseSuccess>> CadastrarEquipe(AdicionaEquipeDTO produto);
        Task<ReponseDTO<ResponseSuccess>> EditarEquipe(EquipeDTO produto, Guid Id);
        Task<ReponseDTO<ResponseSuccess>> ExcluirEquipe(Guid Id);
        List<EquipeDTO> ObterTodosEquipes();
    }
}