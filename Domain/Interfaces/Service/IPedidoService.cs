using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.DTO.Equipe;
using Domain.DTO.Pedido;

namespace Domain.Interfaces.Service
{
    public interface IPedidoService
    {
        Task<ReponseDTO<ResponseSuccess>> CadastrarPedido(CadastroPedidoDTO produto);
        Task<ReponseDTO<ResponseSuccess>> EditarPedido(PedidoDTO produto, Guid Id);
        Task<ReponseDTO<ResponseSuccess>> ExcluirPedido(Guid Id);
        List<PedidoDTO> ObterTodosPedidos(int paginaInicial, int paginaFinal);

 
    }
}