using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.DTO.Produto;

namespace Domain.Interfaces.Service
{
    public interface IProdutoService
    {
        Task<ReponseDTO<ResponseSuccess>> CadastrarProduto(AdicionaProdutoDTO produto);
        Task<ReponseDTO<ResponseSuccess>> EditarProduto(ProdutoDTO produto, Guid Id);
        Task<ReponseDTO<ResponseSuccess>> ExcluirProduto(Guid Id);
        List<ProdutoDTO> ObterTodosProdutos();
    }
}